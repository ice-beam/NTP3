/*
    This file is part of NTP3
    Copyright (C) 2020-2023 boris.mitrin@gmail.com

    NTP3 is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NTP3;
using NTP3.Utils;
using NTP3AnalysisExportGUI.Properties;

namespace NTP3AnalysisExportGUI
{
    partial class MainForm : Form
    {
        private const long ProgressRepaintIntervalMs = 500;
        private const long SettingsSaveIntervalMs = 5000;
        private static readonly ColumnInfo[] SeriesListColumnInfo =
        {
            new ColumnInfo(0, "Series", 105),
            new ColumnInfo(1, "Sample", 55),
            new ColumnInfo(2, "Min.load", 55),
            new ColumnInfo(3, "Max.load", 55),
            new ColumnInfo(4, "Modified", 45),
            new ColumnInfo(5, "Completed", 100),
            new ColumnInfo(6, "Analysed", 100)
        };

        private readonly AnalysisResultReader analysisResultReader = new AnalysisResultReader();
        private bool updating;
        private readonly Stopwatch progressRepaintWatch = new Stopwatch();
        private readonly Stopwatch settingsSaveWatch = new Stopwatch();
        private readonly HashSet<string> invalidatedFolders = new HashSet<string>();
        private readonly HashSet<int> invalidatedSeries = new HashSet<int>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void FillItem(ListViewItem item, IndentationSeriesRecord rec)
        {
            for (int index = 0; index < SeriesListColumnInfo.Length; ++index)
            {
                string text;
                switch (index)
                {
                    case 0:
                        text = rec.SeriesName;
                        if (chkHideSampleNameFromSeriesName.Checked && rec.AdditionalInfo.SampleName != null && text.StartsWith(rec.AdditionalInfo.SampleName))
                        {
                            int length = rec.AdditionalInfo.SampleName.Length;
                            if (text.Length > length + 2)
                            {
                                text = text.Substring(length + 1);
                            }
                        }
                        break;
                    case 1:
                        text = rec.AdditionalInfo.SampleName;
                        break;
                    case 2:
                        text = rec.LoadMin.ToString(CultureInfo.CurrentUICulture);
                        break;
                    case 3:
                        text = rec.LoadMax.ToString(CultureInfo.CurrentUICulture);
                        break;
                    case 4:
                        text = rec.IsModified ? "Yes" : "No";
                        break;
                    case 5:
                        text = rec.ExperimentFinished.ToShortDateString() + " " + rec.ExperimentFinished.ToShortTimeString();
                        break;
                    case 6:
                        text = !rec.IsExperimentAnalysed ? "" : rec.ExperimentAnalysedLast.ToShortDateString() + " " + rec.ExperimentAnalysedLast.ToShortTimeString();
                        break;
                    default:
                        text = "";
                        break;
                }
                if (index == 0)
                    item.Text = text;
                else
                    item.SubItems.Add(text);
            }
        }

        private void RequeryItem(ListViewItem item)
        {
            IndentationSeriesRecord rec = analysisResultReader[(int)item.Tag];
            item.SubItems.Clear();
            FillItem(item, rec);
        }

        private void ProgressRepaint()
        {
            if (progressRepaintWatch.ElapsedMilliseconds < ProgressRepaintIntervalMs)
                return;
            Application.DoEvents();
            progressRepaintWatch.Reset();
        }

        private void ProgressStart(string description, int min, int max)
        {
            Cursor.Current = Cursors.WaitCursor;
            tsProgressBarLabel.Visible = true;
            tsProgressBarLabel.Text = description;
            tsProgressBar.Minimum = min;
            tsProgressBar.Maximum = max;
            tsProgressBar.Value = min;
            tsProgressBar.Visible = min != max;
            statusStrip1.Update();
            ProgressRepaint();
        }

        private void ProgressStatus(int value)
        {
            tsProgressBar.Value = value >= tsProgressBar.Minimum ? (value <= tsProgressBar.Maximum ? value : tsProgressBar.Maximum) : tsProgressBar.Minimum;
            ProgressRepaint();
        }

        private void ProgressFinish()
        {
            tsProgressBar.Visible = false;
            tsProgressBarLabel.Visible = false;
            ProgressRepaint();
            Cursor.Current = Cursors.Default;
        }

        private void ReadInputPath(string path, bool recursive)
        {
            lstSeries.BeginUpdate();
            try
            {
                lstSeries.Items.Clear();
                analysisResultReader.ReadAllFilesAtPath(path, recursive);
                int num = 0;
                foreach (IndentationSeriesRecord rec in analysisResultReader)
                {
                    string str = num.ToString();
                    ListViewItem listViewItem = lstSeries.Items.Add(str, str, -1);
                    listViewItem.Tag = num;
                    FillItem(listViewItem, rec);
                    ++num;
                }
            }
            catch (Exception ex)
            {
                if (recursive)
                    HandleException(ex, "reading input path recursively");
                else
                    HandleException(ex, "reading input path");
            }
            finally
            {
                lstSeries.EndUpdate();
                ProgressFinish();
            }
        }

        private void DoReadInputPath()
        {
            string text = txtInputPath.Text;
            bool recursive = chkRecursive.Checked;
            if (!Directory.Exists(text))
                return;
            ReadInputPath(text, recursive);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.Description = "Select indentation data files path";
                folderBrowserDialog1.SelectedPath = txtInputPath.Text;
                if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                    return;
                txtInputPath.Text = folderBrowserDialog1.SelectedPath;
                DoReadInputPath();
            }
            catch (Exception ex)
            {
                HandleException(ex, "handling browse button");
            }
        }

        private void InitSeriesListColumns()
        {
            for (int index = 0; index < SeriesListColumnInfo.Length; ++index)
            {
                if (SeriesListColumnInfo[index].Id != index)
                    throw new Exception("Internal error: Columns should be ordered by id in SeriesListColumnInfo");
                lstSeries.Columns.Add(SeriesListColumnInfo[index].Name, SeriesListColumnInfo[index].Width);
            }
            lstSeries.Columns[0].DisplayIndex = 1;
        }

        private void InitSeriesListSorter() => lstSeries.ListViewItemSorter = new ListViewColumnComparer(analysisResultReader)
        {
            ColumnIndex = 5,
            Inverse = true
        };

        private void InitAnalysisReaderEventHandlers()
        {
            analysisResultReader.PathLookupStarted += (s, ea) => ProgressStart("Performing lookup...", 0, 0);
            analysisResultReader.PathLookupFinished += (s, ea) => ProgressStart("Reading data:", 0, analysisResultReader.SeriesCount);
            analysisResultReader.SeriesReadingFinished += (s, ea) => ProgressStatus(ea.SeriesIndex + 1);
            analysisResultReader.PathReadingFinished += (s, ea) => ProgressFinish();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                progressRepaintWatch.Start();
                settingsSaveWatch.Start();
                InitSeriesListColumns();
                InitSeriesListSorter();
                InitAnalysisReaderEventHandlers();
                LoadSettings();
                DoReadInputPath();
            }
            catch (Exception ex)
            {
                HandleException(ex, "loading the main form");
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                HandleException(ex, "closing the form");
            }
        }

        private bool ReadPath(out string path)
        {
            path = !optExportToSamePath.Checked ? txtExportPath.Text : txtInputPath.Text;
            if (!Directory.Exists(path))
            {
                MessageBox.Show("Export path does not exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (path.Length > 0 && path[path.Length - 1] != '\\')
                path += '\\';
            return true;
        }

        private void ShowOpenExportedFileDialog(string filePath)
        {
            try
            {
                if (MessageBox.Show("Export completed.\nOpen exported file?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
                    return;
                Process.Start(filePath);
            }
            catch (Exception ex)
            {
                HandleException(ex, "opening export file");
            }
        }

        private void btnExportInd_Click(object sender, EventArgs e)
        {
            try
            {
                string path;
                if (!ReadPath(out path))
                    return;
                string str = path + "analysis.txt";
                IReadOnlyList<AnalysisExportColumnSpecification> columns = lstFieldsInd.CheckedItems.Cast<AnalysisExportColumnSpecification>().ToList();
                using (FileStream fileStream = new FileStream(str, FileMode.Create))
                {
                    using (StreamWriter osw = new StreamWriter(fileStream))
                    {
                        analysisResultReader.WriteColumnsToStream(osw, columns);
                        IEnumerable enumerable;
                        int count;
                        if (lstSeries.SelectedIndices.Count == 0)
                        {
                            enumerable = lstSeries.Items;
                            count = lstSeries.Items.Count;
                        }
                        else
                        {
                            enumerable = lstSeries.SelectedItems;
                            count = lstSeries.SelectedItems.Count;
                        }
                        List<int> intList = new List<int>(count);
                        foreach (ListViewItem listViewItem in enumerable)
                        {
                            int num = listViewItem.Tag != null ? (int)listViewItem.Tag : -1;
                            if (num > -1)
                            {
                                if (chkExportOnlyLastModified.Checked)
                                {
                                    int modifiedSeriesNo = analysisResultReader[num].LastModifiedSeriesNo;
                                    if (!intList.Contains(modifiedSeriesNo))
                                    {
                                        analysisResultReader.WriteSeriesToStream(osw, modifiedSeriesNo, columns);
                                        intList.Add(modifiedSeriesNo);
                                    }
                                }
                                else
                                    analysisResultReader.WriteSeriesToStream(osw, num, columns);
                            }
                        }
                        osw.Flush();
                    }
                }
                ShowOpenExportedFileDialog(str);
            }
            catch (Exception ex)
            {
                HandleException(ex, "handling the export individual button");
            }
        }

        private void btnExportAvg_Click(object sender, EventArgs e)
        {
            try
            {
                string path;
                if (!ReadPath(out path))
                    return;
                string str = path + "analysis.avg.txt";
                IReadOnlyList<AnalysisExportColumnSpecification> columns = lstFieldsAvg.CheckedItems.Cast<AnalysisExportColumnSpecification>().ToList();
                using (FileStream fileStream = new FileStream(str, FileMode.Create))
                {
                    using (StreamWriter osw = new StreamWriter(fileStream))
                    {
                        analysisResultReader.WriteColumnsToStream(osw, columns);
                        IEnumerable enumerable;
                        int count;
                        if (lstSeries.SelectedIndices.Count == 0)
                        {
                            enumerable = lstSeries.Items;
                            count = lstSeries.Items.Count;
                        }
                        else
                        {
                            enumerable = lstSeries.SelectedItems;
                            count = lstSeries.SelectedItems.Count;
                        }
                        List<int> intList = new List<int>(count);
                        foreach (ListViewItem listViewItem in enumerable)
                        {
                            int num = listViewItem.Tag != null ? (int)listViewItem.Tag : -1;
                            if (num > -1)
                            {
                                if (chkExportOnlyLastModified.Checked)
                                {
                                    int modifiedSeriesNo = analysisResultReader[num].LastModifiedSeriesNo;
                                    if (!intList.Contains(modifiedSeriesNo))
                                    {
                                        analysisResultReader.WriteSeriesAvgToStream(osw, modifiedSeriesNo, columns);
                                        intList.Add(modifiedSeriesNo);
                                    }
                                }
                                else
                                    analysisResultReader.WriteSeriesAvgToStream(osw, num, columns);
                            }
                        }
                        osw.Flush();
                    }
                }
                ShowOpenExportedFileDialog(str);
            }
            catch (Exception ex)
            {
                HandleException(ex, "handling the export average button");
            }
        }

        private void FillFieldsList(
          string namesOrder,
          string selectedNames,
          bool average,
          CheckedListBox list)
        {
            List<AnalysisExportColumnSpecification> fieldsSpecs = new List<AnalysisExportColumnSpecification>(AnalysisExportColumnSpecification.GetOrdered(namesOrder.Split(',')));
            IEnumerable<AnalysisExportColumnSpecification> collection = AnalysisExportColumnSpecification.Specifications.Where(x =>
            {
                if (fieldsSpecs.Contains(x))
                    return false;
                return !x.AverageOnly || x.AverageOnly == average;
            });
            fieldsSpecs.AddRange(collection);
            List<AnalysisExportColumnSpecification> columnSpecificationList = new List<AnalysisExportColumnSpecification>(AnalysisExportColumnSpecification.Get(selectedNames.Split(',')));
            foreach (AnalysisExportColumnSpecification columnSpecification in fieldsSpecs)
                list.Items.Add(columnSpecification, columnSpecificationList.Contains(columnSpecification));
        }

        private void LoadSettings()
        {
            // ISSUE: variable of a compiler-generated type
            Settings settings = Settings.Default;
            updating = true;
            try
            {
                txtInputPath.Text = settings.InputPath;
                chkRecursive.Checked = settings.InputRecursive;
                optExportToSamePath.Checked = settings.ExportToSamePath;
                optExportToAnotherPath.Checked = !settings.ExportToSamePath;
                txtExportPath.Text = settings.ExportPath;
                chkHideSampleNameFromSeriesName.Checked = settings.HideSampleNameFromSeriesName;
                chkExportOnlyLastModified.Checked = settings.ExportOnlyLastModified;
                Screen screen = Screen.FromControl(this);
                Size point1 = GuiUtils.PairStringToPoint(settings.WindowSize, Size);
                point1.Width = Math.Max(Size.Width, Math.Min(point1.Width, screen.Bounds.Width));
                point1.Height = Math.Max(Size.Height, Math.Min(point1.Height, screen.Bounds.Height));
                Size = point1;
                Point point2 = GuiUtils.PairStringToPoint(settings.WindowLocaton, Location);
                point2.X = Math.Max(0, Math.Min(point2.X, screen.Bounds.Width - point1.Width));
                point2.Y = Math.Max(0, Math.Min(point2.Y, screen.Bounds.Height - point1.Height));
                Location = point2;
                FillFieldsList(settings.ExportFieldsIndOrder, settings.ExportFieldsIndSelected, false, lstFieldsInd);
                FillFieldsList(settings.ExportFieldsAvgOrder, settings.ExportFieldsAvgSelected, true, lstFieldsAvg);
            }
            finally
            {
                updating = false;
            }
        }

        private IEnumerable<string> ExtractSpecificiationNames(IEnumerable list) => list.Cast<AnalysisExportColumnSpecification>().Select(x => x.Name);

        private void SaveSettings()
        {
            // ISSUE: variable of a compiler-generated type
            Settings settings = Settings.Default;
            settings.InputPath = txtInputPath.Text;
            settings.InputRecursive = chkRecursive.Checked;
            settings.ExportToSamePath = optExportToSamePath.Checked;
            settings.ExportPath = txtExportPath.Text;
            settings.HideSampleNameFromSeriesName = chkHideSampleNameFromSeriesName.Checked;
            settings.ExportOnlyLastModified = chkExportOnlyLastModified.Checked;
            settings.ExportFieldsIndOrder = string.Join(",", ExtractSpecificiationNames(lstFieldsInd.Items));
            settings.ExportFieldsIndSelected = string.Join(",", ExtractSpecificiationNames(lstFieldsInd.CheckedItems));
            settings.ExportFieldsAvgOrder = string.Join(",", ExtractSpecificiationNames(lstFieldsAvg.Items));
            settings.ExportFieldsAvgSelected = string.Join(",", ExtractSpecificiationNames(lstFieldsAvg.CheckedItems));
            settings.WindowLocaton = GuiUtils.PointToPairString(Location);
            settings.WindowSize = GuiUtils.PointToPairString(Size);
            settings.Save();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) => SaveSettings();

        private void btnExportBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.Description = "Select export directory";
                folderBrowserDialog1.SelectedPath = txtExportPath.Text;
                if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                    return;
                txtExportPath.Text = folderBrowserDialog1.SelectedPath;
                optExportToAnotherPath.Checked = true;
            }
            catch (Exception ex)
            {
                HandleException(ex, "handling the export browse button");
            }
        }

        private void lstSeries_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                if (lstSeries.ListViewItemSorter == null)
                    lstSeries.ListViewItemSorter = new ListViewColumnComparer(analysisResultReader);
                ListViewColumnComparer listViewItemSorter = (ListViewColumnComparer)lstSeries.ListViewItemSorter;
                if (listViewItemSorter.ColumnIndex == e.Column)
                {
                    listViewItemSorter.Inverse = !listViewItemSorter.Inverse;
                }
                else
                {
                    listViewItemSorter.ColumnIndex = e.Column;
                    listViewItemSorter.Inverse = false;
                }
                lstSeries.Sort();
            }
            catch (Exception ex)
            {
                HandleException(ex, "handling the series list column click");
            }
        }

        private void chkRecursive_CheckedChanged(object sender, EventArgs e)
        {
            if (updating)
                return;
            DoReadInputPath();
        }

        private void lstSeries_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Right)
                    return;
                contextMenuStrip1.Show(lstSeries, e.Location);
            }
            catch (Exception ex)
            {
                HandleException(ex, "handling the series list mouse click");
            }
        }

        private void InvalidateFolder(string path)
        {
            invalidatedFolders.Add(path);
        }

        private void InvalidateSeries(int si) => invalidatedSeries.Add(si);

        private void RefreshListView()
        {
            lstSeries.BeginUpdate();
            HashSet<int> intSet = new HashSet<int>();
            foreach (ListViewItem listViewItem in lstSeries.Items)
            {
                int tag = (int)listViewItem.Tag;
                if (invalidatedFolders.Contains(analysisResultReader[tag].FolderName))
                    intSet.Add(tag);
            }
            foreach (int num in invalidatedSeries)
                intSet.Add(num);
            foreach (ListViewItem listViewItem in lstSeries.Items)
            {
                int tag = (int)listViewItem.Tag;
                if (intSet.Contains(tag))
                {
                    analysisResultReader.InvalidateSeries(tag);
                    RequeryItem(listViewItem);
                }
            }
            invalidatedFolders.Clear();
            invalidatedSeries.Clear();
            lstSeries.EndUpdate();
        }

        private void editAdditionalPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ParametersForm parametersForm = new ParametersForm();
                if (lstSeries.SelectedItems.Count < 1)
                    return;
                int tag1 = (int)lstSeries.SelectedItems[0].Tag;
                AdditionalInfo folderAdditionalInfo1 = analysisResultReader[tag1].FolderAdditionalInfo;
                AdditionalInfo fileAdditionalInfo1 = analysisResultReader[tag1].FileAdditionalInfo;
                string str = analysisResultReader[tag1].FolderName;
                string name = analysisResultReader[tag1].SeriesName;
                for (int index = 1; index < lstSeries.SelectedItems.Count; ++index)
                {
                    int tag2 = (int)lstSeries.SelectedItems[index].Tag;
                    if (analysisResultReader[tag2].FileAdditionalInfo.SampleName != fileAdditionalInfo1.SampleName)
                        fileAdditionalInfo1.SampleName = AdditionalInfo.StringVarietyCode;
                    if (analysisResultReader[tag2].FolderAdditionalInfo.SampleName != folderAdditionalInfo1.SampleName)
                        folderAdditionalInfo1.SampleName = AdditionalInfo.StringVarietyCode;
                    if (analysisResultReader[tag2].FolderName != str)
                        str = AdditionalInfo.StringVarietyCode;
                    if (analysisResultReader[tag2].SeriesName != name)
                        name = AdditionalInfo.StringVarietyCode;
                }
                parametersForm.SetFolderAdditionalInfo(folderAdditionalInfo1);
                parametersForm.SetFileAdditionalInfo(fileAdditionalInfo1);
                parametersForm.SetFolderName(str);
                parametersForm.SetFileName(name);
                if (parametersForm.ShowDialog(this) != DialogResult.OK)
                    return;
                AdditionalInfo folderAdditionalInfo2 = parametersForm.GetFolderAdditionalInfo();
                AdditionalInfo fileAdditionalInfo2 = parametersForm.GetFileAdditionalInfo();
                try
                {
                    AdditionalInfoWriter additionalInfoWriter = new AdditionalInfoWriter();
                    foreach (ListViewItem selectedItem in lstSeries.SelectedItems)
                    {
                        int tag3 = (int)selectedItem.Tag;
                        additionalInfoWriter.WriteFolderAdditionalInfo(folderAdditionalInfo2, analysisResultReader[tag3].FolderName, analysisResultReader[tag3].SeriesName);
                        additionalInfoWriter.WriteFileAdditionalInfo(fileAdditionalInfo2, analysisResultReader[tag3].FolderName, analysisResultReader[tag3].SeriesName);
                        InvalidateFolder(str);
                    }
                }
                catch (Exception ex)
                {
                    HandleException(ex, "writing additional properties to files");
                }
                RefreshListView();
            }
            catch (Exception ex)
            {
                HandleException(ex, "handling edit additional info menu item");
            }
        }

        private void HandleException(Exception e, string cause = null)
        {
            ErrorForm errorForm = new ErrorForm();
            errorForm.SetErrorMessage(e.ToString());
            errorForm.SetCause(cause);
            errorForm.ShowDialog(this);
        }

        private void renameSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstSeries.SelectedItems.Count < 1)
                    return;
                int tag = (int)lstSeries.SelectedItems[0].Tag;
                RenameForm renameForm = new RenameForm();
                IndentationSeriesRecord record = analysisResultReader[tag];
                string folderName = record.FolderName;
                DirectoryInfo directoryInfo = new DirectoryInfo(folderName);
                string seriesName = record.SeriesName;
                renameForm.SetFolderName(folderName);
                renameForm.SetOldFileName(seriesName);
                while (renameForm.ShowDialog(this) != DialogResult.Cancel)
                {
                    string newFileName = renameForm.GetNewFileName();
                    if (directoryInfo.GetFiles(newFileName + ".*").Length != 0)
                    {
                        MessageBox.Show(this, "Files with name\n" + newFileName + "\nalready exist in the target folder.", "File exists", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        try
                        {
                            FileInfo[] files = directoryInfo.GetFiles(seriesName + ".*");
                            foreach (FileInfo file in files)
                            {
                                while (file.IsInUse())
                                {
                                    if (MessageBox.Show(this, "One of series file is in use:\n" + file.Name + "\nTry again?", "File is in use", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                                        return;
                                }
                            }
                            foreach (FileInfo fileInfo in files)
                                fileInfo.MoveTo(folderName + "\\" + newFileName + fileInfo.Extension);
                            record.SeriesName = newFileName;
                            analysisResultReader.ReplaceSeries(tag, record);
                            InvalidateSeries(tag);
                            RefreshListView();
                            break;
                        }
                        catch (Exception ex)
                        {
                            HandleException(ex, "renaming series");
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "handling rename series menu item");
            }
        }

        private void openContainingFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstSeries.SelectedItems.Count < 1)
                    return;
                int tag = (int)lstSeries.SelectedItems[0].Tag;
                string folderName = analysisResultReader[tag].FolderName;
                if (lstSeries.SelectedItems.Count > 1)
                {
                    Process.Start(folderName);
                }
                else
                {
                    string seriesName = analysisResultReader[tag].SeriesName;
                    Process.Start("explorer.exe", "/select, \"" + (folderName + "\\" + seriesName + ".ind") + "\"");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "handling open containing folder menu item");
            }
        }

        private void MoveUpCheckedListBoxItem(CheckedListBox list)
        {
            int selectedIndex = list.SelectedIndex;
            if (selectedIndex <= 0)
                return;
            object obj = list.Items[selectedIndex - 1];
            bool itemChecked = list.GetItemChecked(selectedIndex - 1);
            list.Items.RemoveAt(selectedIndex - 1);
            list.Items.Insert(selectedIndex, obj);
            list.SetItemChecked(selectedIndex, itemChecked);
        }

        private void MoveDownCheckedListBoxItem(CheckedListBox list)
        {
            int selectedIndex = list.SelectedIndex;
            if (selectedIndex >= list.Items.Count - 1)
                return;
            object obj = list.Items[selectedIndex + 1];
            bool itemChecked = list.GetItemChecked(selectedIndex + 1);
            list.Items.RemoveAt(selectedIndex + 1);
            list.Items.Insert(selectedIndex, obj);
            list.SetItemChecked(selectedIndex, itemChecked);
        }

        private void btnFieldIndUp_Click(object sender, EventArgs e) => MoveUpCheckedListBoxItem(lstFieldsInd);

        private void btnFieldIndDown_Click(object sender, EventArgs e) => MoveDownCheckedListBoxItem(lstFieldsInd);

        private void btnFieldAvgUp_Click(object sender, EventArgs e) => MoveUpCheckedListBoxItem(lstFieldsAvg);

        private void btnFieldAvgDown_Click(object sender, EventArgs e) => MoveDownCheckedListBoxItem(lstFieldsAvg);

        private void tabControlMain_TabIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.TabIndex != 0)
                return;
            SaveSettings();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            if (settingsSaveWatch.ElapsedTicks < SettingsSaveIntervalMs)
                return;
            settingsSaveWatch.Reset();
            SaveSettings();
        }

        

        private struct ColumnInfo
        {
            public int Id;
            public string Name;
            public int Width;

            public ColumnInfo(int id, string name, int width)
            {
                Id = id;
                Name = name;
                Width = width;
            }
        }

        private class ListViewColumnComparer : IComparer
        {
            public int ColumnIndex { get; set; }

            public bool Inverse { get; set; }

            public AnalysisResultReader Results { get; private set; }

            public ListViewColumnComparer(AnalysisResultReader results)
            {
                Results = results;
                ColumnIndex = 0;
                Inverse = false;
            }

            public int Compare(object x, object y)
            {
                if (x == null || y == null)
                    return 0;
                ListViewItem listViewItem1 = (ListViewItem)x;
                ListViewItem listViewItem2 = (ListViewItem)y;
                IndentationSeriesRecord result1 = Results[(int)(listViewItem1.Tag ?? 0)];
                IndentationSeriesRecord result2 = Results[(int)(listViewItem2.Tag ?? 0)];
                int num = Inverse ? -1 : 1;
                try
                {
                    switch (ColumnIndex)
                    {
                        case 2:
                            return num * Math.Sign(result1.LoadMin - result2.LoadMin);
                        case 3:
                            return num * Math.Sign(result1.LoadMax - result2.LoadMax);
                        case 5:
                            return num * DateTime.Compare(result1.ExperimentFinished, result2.ExperimentFinished);
                        case 6:
                            return num * DateTime.Compare(result1.ExperimentAnalysedLast, result2.ExperimentAnalysedLast);
                        default:
                            return num * StringUtils.CompareLogical(((ListViewItem)x).SubItems[ColumnIndex].Text, ((ListViewItem)y).SubItems[ColumnIndex].Text);
                    }
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}
