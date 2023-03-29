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
using System.Windows.Forms;
using NTP3;

namespace NTP3AnalysisExportGUI
{
    public partial class ParametersForm : Form
    {
        private const string VarietyDescription = "(various)";

        public ParametersForm() => InitializeComponent();

        private void SetStatedTextValue(Control ctl, CheckBox chk, string value)
        {
            if (value == AdditionalInfo.StringVarietyCode)
            {
                chk.CheckState = CheckState.Indeterminate;
                ctl.Text = "";
                ctl.Enabled = true;
            }
            else if (value == null || value == AdditionalInfo.StringEmptyCode)
            {
                chk.CheckState = CheckState.Unchecked;
                ctl.Text = "";
                ctl.Enabled = false;
            }
            else
            {
                chk.CheckState = CheckState.Checked;
                ctl.Text = value;
                ctl.Enabled = true;
            }
        }

        private void SetStatedFloatValue(Control ctl, CheckBox chk, float value, string format)
        {
            if (AdditionalInfo.IsVariety(value))
            {
                chk.CheckState = CheckState.Indeterminate;
                ctl.Text = "";
                ctl.Enabled = true;
            }
            else if (AdditionalInfo.IsEmpty(value))
            {
                chk.CheckState = CheckState.Unchecked;
                ctl.Text = "";
                ctl.Enabled = false;
            }
            else
            {
                chk.CheckState = CheckState.Checked;
                ctl.Text = value.ToString(format);
                ctl.Enabled = true;
            }
        }

        private string GetStatedStringValue(string value, CheckState state)
        {
            if (state == CheckState.Indeterminate)
                return AdditionalInfo.StringVarietyCode;
            return state == CheckState.Unchecked ? AdditionalInfo.StringEmptyCode : value;
        }

        private float GetStatedFloatValue(string value, CheckState state)
        {
            if (state == CheckState.Indeterminate)
                return AdditionalInfo.FloatVarietyCode;
            return state == CheckState.Unchecked ? AdditionalInfo.FloatEmptyCode : float.Parse(value);
        }

        public void SetFileName(string name)
        {
            if (AdditionalInfo.IsVariety(name))
                txtFileName.Text = VarietyDescription;
            else
                txtFileName.Text = name;
        }

        public void SetFolderName(string name)
        {
            if (AdditionalInfo.IsVariety(name))
                txtFolderName.Text = VarietyDescription;
            else
                txtFolderName.Text = name;
        }

        public AdditionalInfo GetFileAdditionalInfo()
        {
            AdditionalInfo fileAdditionalInfo;
            fileAdditionalInfo.SampleName = GetStatedStringValue(cmbFileSampleName.Text, chkFileSampleName.CheckState);
            fileAdditionalInfo.OperatorName = GetStatedStringValue(cmbFileOperatorName.Text, chkFileOperatorName.CheckState);
            fileAdditionalInfo.OrderNumber = GetStatedStringValue(cmbFileOrderName.Text, chkFileOrderName.CheckState);
            fileAdditionalInfo.Nu = GetStatedFloatValue(txtFileNu.Text, chkFileNu.CheckState);
            return fileAdditionalInfo;
        }

        public AdditionalInfo GetFolderAdditionalInfo()
        {
            AdditionalInfo folderAdditionalInfo;
            folderAdditionalInfo.SampleName = GetStatedStringValue(cmbFolderSampleName.Text, chkFolderSampleName.CheckState);
            folderAdditionalInfo.OperatorName = GetStatedStringValue(cmbFolderOperatorName.Text, chkFolderOperatorName.CheckState);
            folderAdditionalInfo.OrderNumber = GetStatedStringValue(cmbFolderOrderName.Text, chkFolderOrderName.CheckState);
            folderAdditionalInfo.Nu = GetStatedFloatValue(txtFolderNu.Text, chkFolderNu.CheckState);
            return folderAdditionalInfo;
        }

        public void SetFileAdditionalInfo(AdditionalInfo info)
        {
            SetStatedTextValue(cmbFileSampleName, chkFileSampleName, info.SampleName);
            SetStatedTextValue(cmbFileOperatorName, chkFileOperatorName, info.OperatorName);
            SetStatedTextValue(cmbFileOrderName, chkFileOrderName, info.OrderNumber);
            SetStatedFloatValue(txtFileNu, chkFileNu, info.Nu, "F3");
        }

        public void SetFolderAdditionalInfo(AdditionalInfo info)
        {
            SetStatedTextValue(cmbFolderSampleName, chkFolderSampleName, info.SampleName);
            SetStatedTextValue(cmbFolderOperatorName, chkFolderOperatorName, info.OperatorName);
            SetStatedTextValue(cmbFolderOrderName, chkFolderOrderName, info.OrderNumber);
            SetStatedFloatValue(txtFolderNu, chkFolderNu, info.Nu, "F3");
        }

        private void chkFolderSampleName_CheckedChanged(object sender, EventArgs e) => cmbFolderSampleName.Enabled = chkFolderSampleName.CheckState != CheckState.Unchecked;

        private void chkFolderOperatorName_CheckedChanged(object sender, EventArgs e) => cmbFolderOperatorName.Enabled = chkFolderOperatorName.CheckState != CheckState.Unchecked;

        private void chkFolderOrderName_CheckedChanged(object sender, EventArgs e) => cmbFolderOrderName.Enabled = chkFolderOrderName.CheckState != CheckState.Unchecked;

        private void chkFileSampleName_CheckedChanged(object sender, EventArgs e) => cmbFileSampleName.Enabled = chkFileSampleName.CheckState != CheckState.Unchecked;

        private void chkFileOperatorName_CheckedChanged(object sender, EventArgs e) => cmbFileOperatorName.Enabled = chkFileOperatorName.CheckState != CheckState.Unchecked;

        private void chkFileOrderName_CheckedChanged(object sender, EventArgs e) => cmbFileOrderName.Enabled = chkFileOrderName.CheckState != CheckState.Unchecked;

        private void chkFolderNu_CheckedChanged(object sender, EventArgs e) => txtFolderNu.Enabled = chkFolderNu.CheckState != CheckState.Unchecked;

        private void chkFileNu_CheckedChanged(object sender, EventArgs e) => txtFileNu.Enabled = chkFileNu.CheckState != CheckState.Unchecked;
    }
}
