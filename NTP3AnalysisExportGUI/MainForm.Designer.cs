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
namespace NTP3AnalysisExportGUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInputPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.btnExportInd = new System.Windows.Forms.Button();
            this.btnExportAvg = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.optExportToSamePath = new System.Windows.Forms.RadioButton();
            this.optExportToAnotherPath = new System.Windows.Forms.RadioButton();
            this.btnExportBrowse = new System.Windows.Forms.Button();
            this.txtExportPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabExperiments = new System.Windows.Forms.TabPage();
            this.lstSeries = new System.Windows.Forms.ListView();
            this.tabDisplaySettings = new System.Windows.Forms.TabPage();
            this.chkHideSampleNameFromSeriesName = new System.Windows.Forms.CheckBox();
            this.tabExportSettings = new System.Windows.Forms.TabPage();
            this.chkExportOnlyLastModified = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFieldAvgDown = new System.Windows.Forms.Button();
            this.btnFieldAvgUp = new System.Windows.Forms.Button();
            this.lstFieldsAvg = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFieldIndDown = new System.Windows.Forms.Button();
            this.btnFieldIndUp = new System.Windows.Forms.Button();
            this.lstFieldsInd = new System.Windows.Forms.CheckedListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editAdditionalPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openContainingFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSeriesInNTPlatformAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsProgressBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tabControlMain.SuspendLayout();
            this.tabExperiments.SuspendLayout();
            this.tabDisplaySettings.SuspendLayout();
            this.tabExportSettings.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Directory:";
            // 
            // txtInputPath
            // 
            this.txtInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputPath.Location = new System.Drawing.Point(100, 18);
            this.txtInputPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInputPath.Name = "txtInputPath";
            this.txtInputPath.Size = new System.Drawing.Size(510, 26);
            this.txtInputPath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(621, 17);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(112, 35);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "&Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // chkRecursive
            // 
            this.chkRecursive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRecursive.AutoSize = true;
            this.chkRecursive.Location = new System.Drawing.Point(747, 23);
            this.chkRecursive.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(105, 24);
            this.chkRecursive.TabIndex = 3;
            this.chkRecursive.Text = "Recursive";
            this.chkRecursive.UseVisualStyleBackColor = true;
            this.chkRecursive.CheckedChanged += new System.EventHandler(this.chkRecursive_CheckedChanged);
            // 
            // btnExportInd
            // 
            this.btnExportInd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportInd.Location = new System.Drawing.Point(18, 435);
            this.btnExportInd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExportInd.Name = "btnExportInd";
            this.btnExportInd.Size = new System.Drawing.Size(112, 35);
            this.btnExportInd.TabIndex = 6;
            this.btnExportInd.Text = "&Export";
            this.btnExportInd.UseVisualStyleBackColor = true;
            this.btnExportInd.Click += new System.EventHandler(this.btnExportInd_Click);
            // 
            // btnExportAvg
            // 
            this.btnExportAvg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportAvg.Location = new System.Drawing.Point(140, 435);
            this.btnExportAvg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExportAvg.Name = "btnExportAvg";
            this.btnExportAvg.Size = new System.Drawing.Size(152, 35);
            this.btnExportAvg.TabIndex = 7;
            this.btnExportAvg.Text = "Export &average";
            this.btnExportAvg.UseVisualStyleBackColor = true;
            this.btnExportAvg.Click += new System.EventHandler(this.btnExportAvg_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.Location = new System.Drawing.Point(740, 435);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(112, 35);
            this.btnQuit.TabIndex = 8;
            this.btnQuit.Text = "&Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 395);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Export to:";
            // 
            // optExportToSamePath
            // 
            this.optExportToSamePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optExportToSamePath.AutoSize = true;
            this.optExportToSamePath.Location = new System.Drawing.Point(104, 394);
            this.optExportToSamePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.optExportToSamePath.Name = "optExportToSamePath";
            this.optExportToSamePath.Size = new System.Drawing.Size(109, 24);
            this.optExportToSamePath.TabIndex = 10;
            this.optExportToSamePath.TabStop = true;
            this.optExportToSamePath.Text = "same path";
            this.optExportToSamePath.UseVisualStyleBackColor = true;
            // 
            // optExportToAnotherPath
            // 
            this.optExportToAnotherPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optExportToAnotherPath.AutoSize = true;
            this.optExportToAnotherPath.Location = new System.Drawing.Point(224, 394);
            this.optExportToAnotherPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.optExportToAnotherPath.Name = "optExportToAnotherPath";
            this.optExportToAnotherPath.Size = new System.Drawing.Size(71, 24);
            this.optExportToAnotherPath.TabIndex = 11;
            this.optExportToAnotherPath.TabStop = true;
            this.optExportToAnotherPath.Text = "other";
            this.optExportToAnotherPath.UseVisualStyleBackColor = true;
            // 
            // btnExportBrowse
            // 
            this.btnExportBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportBrowse.Location = new System.Drawing.Point(740, 391);
            this.btnExportBrowse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExportBrowse.Name = "btnExportBrowse";
            this.btnExportBrowse.Size = new System.Drawing.Size(112, 35);
            this.btnExportBrowse.TabIndex = 12;
            this.btnExportBrowse.Text = "&Browse...";
            this.btnExportBrowse.UseVisualStyleBackColor = true;
            this.btnExportBrowse.Click += new System.EventHandler(this.btnExportBrowse_Click);
            // 
            // txtExportPath
            // 
            this.txtExportPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExportPath.Location = new System.Drawing.Point(306, 391);
            this.txtExportPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtExportPath.Name = "txtExportPath";
            this.txtExportPath.Size = new System.Drawing.Size(422, 26);
            this.txtExportPath.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(500, 443);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(233, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "(C)2023 boris.mitrin@gmail.com";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabExperiments);
            this.tabControlMain.Controls.Add(this.tabDisplaySettings);
            this.tabControlMain.Controls.Add(this.tabExportSettings);
            this.tabControlMain.Location = new System.Drawing.Point(18, 58);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(834, 323);
            this.tabControlMain.TabIndex = 15;
            this.tabControlMain.TabIndexChanged += new System.EventHandler(this.tabControlMain_TabIndexChanged);
            // 
            // tabExperiments
            // 
            this.tabExperiments.Controls.Add(this.lstSeries);
            this.tabExperiments.Location = new System.Drawing.Point(4, 29);
            this.tabExperiments.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabExperiments.Name = "tabExperiments";
            this.tabExperiments.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabExperiments.Size = new System.Drawing.Size(826, 290);
            this.tabExperiments.TabIndex = 0;
            this.tabExperiments.Text = "Experiments";
            this.tabExperiments.UseVisualStyleBackColor = true;
            // 
            // lstSeries
            // 
            this.lstSeries.AllowColumnReorder = true;
            this.lstSeries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSeries.FullRowSelect = true;
            this.lstSeries.GridLines = true;
            this.lstSeries.HideSelection = false;
            this.lstSeries.Location = new System.Drawing.Point(9, 9);
            this.lstSeries.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstSeries.Name = "lstSeries";
            this.lstSeries.Size = new System.Drawing.Size(802, 262);
            this.lstSeries.TabIndex = 6;
            this.lstSeries.UseCompatibleStateImageBehavior = false;
            this.lstSeries.View = System.Windows.Forms.View.Details;
            this.lstSeries.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstSeries_ColumnClick);
            this.lstSeries.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstSeries_MouseClick);
            // 
            // tabDisplaySettings
            // 
            this.tabDisplaySettings.Controls.Add(this.chkHideSampleNameFromSeriesName);
            this.tabDisplaySettings.Location = new System.Drawing.Point(4, 29);
            this.tabDisplaySettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabDisplaySettings.Name = "tabDisplaySettings";
            this.tabDisplaySettings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabDisplaySettings.Size = new System.Drawing.Size(826, 290);
            this.tabDisplaySettings.TabIndex = 2;
            this.tabDisplaySettings.Text = "Display settings";
            this.tabDisplaySettings.UseVisualStyleBackColor = true;
            // 
            // chkHideSampleNameFromSeriesName
            // 
            this.chkHideSampleNameFromSeriesName.AutoSize = true;
            this.chkHideSampleNameFromSeriesName.Location = new System.Drawing.Point(9, 9);
            this.chkHideSampleNameFromSeriesName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkHideSampleNameFromSeriesName.Name = "chkHideSampleNameFromSeriesName";
            this.chkHideSampleNameFromSeriesName.Size = new System.Drawing.Size(293, 24);
            this.chkHideSampleNameFromSeriesName.TabIndex = 1;
            this.chkHideSampleNameFromSeriesName.Text = "Hide sample name from series name";
            this.chkHideSampleNameFromSeriesName.UseVisualStyleBackColor = true;
            // 
            // tabExportSettings
            // 
            this.tabExportSettings.Controls.Add(this.chkExportOnlyLastModified);
            this.tabExportSettings.Controls.Add(this.label5);
            this.tabExportSettings.Controls.Add(this.btnFieldAvgDown);
            this.tabExportSettings.Controls.Add(this.btnFieldAvgUp);
            this.tabExportSettings.Controls.Add(this.lstFieldsAvg);
            this.tabExportSettings.Controls.Add(this.label2);
            this.tabExportSettings.Controls.Add(this.btnFieldIndDown);
            this.tabExportSettings.Controls.Add(this.btnFieldIndUp);
            this.tabExportSettings.Controls.Add(this.lstFieldsInd);
            this.tabExportSettings.Location = new System.Drawing.Point(4, 29);
            this.tabExportSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabExportSettings.Name = "tabExportSettings";
            this.tabExportSettings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabExportSettings.Size = new System.Drawing.Size(826, 290);
            this.tabExportSettings.TabIndex = 1;
            this.tabExportSettings.Text = "Export settings";
            this.tabExportSettings.UseVisualStyleBackColor = true;
            // 
            // chkExportOnlyLastModified
            // 
            this.chkExportOnlyLastModified.AutoSize = true;
            this.chkExportOnlyLastModified.Location = new System.Drawing.Point(9, 9);
            this.chkExportOnlyLastModified.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkExportOnlyLastModified.Name = "chkExportOnlyLastModified";
            this.chkExportOnlyLastModified.Size = new System.Drawing.Size(206, 24);
            this.chkExportOnlyLastModified.TabIndex = 9;
            this.chkExportOnlyLastModified.Text = "Export only last modified";
            this.chkExportOnlyLastModified.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(405, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Columns (average):";
            // 
            // btnFieldAvgDown
            // 
            this.btnFieldAvgDown.Location = new System.Drawing.Point(700, 109);
            this.btnFieldAvgDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFieldAvgDown.Name = "btnFieldAvgDown";
            this.btnFieldAvgDown.Size = new System.Drawing.Size(112, 35);
            this.btnFieldAvgDown.TabIndex = 7;
            this.btnFieldAvgDown.Text = "Move dow&n";
            this.btnFieldAvgDown.UseVisualStyleBackColor = true;
            this.btnFieldAvgDown.Click += new System.EventHandler(this.btnFieldAvgDown_Click);
            // 
            // btnFieldAvgUp
            // 
            this.btnFieldAvgUp.Location = new System.Drawing.Point(700, 65);
            this.btnFieldAvgUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFieldAvgUp.Name = "btnFieldAvgUp";
            this.btnFieldAvgUp.Size = new System.Drawing.Size(112, 35);
            this.btnFieldAvgUp.TabIndex = 6;
            this.btnFieldAvgUp.Text = "Move u&p";
            this.btnFieldAvgUp.UseVisualStyleBackColor = true;
            this.btnFieldAvgUp.Click += new System.EventHandler(this.btnFieldAvgUp_Click);
            // 
            // lstFieldsAvg
            // 
            this.lstFieldsAvg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstFieldsAvg.FormattingEnabled = true;
            this.lstFieldsAvg.Location = new System.Drawing.Point(410, 65);
            this.lstFieldsAvg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstFieldsAvg.Name = "lstFieldsAvg";
            this.lstFieldsAvg.Size = new System.Drawing.Size(283, 211);
            this.lstFieldsAvg.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Columns (invididual curves):";
            // 
            // btnFieldIndDown
            // 
            this.btnFieldIndDown.Location = new System.Drawing.Point(288, 109);
            this.btnFieldIndDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFieldIndDown.Name = "btnFieldIndDown";
            this.btnFieldIndDown.Size = new System.Drawing.Size(112, 35);
            this.btnFieldIndDown.TabIndex = 3;
            this.btnFieldIndDown.Text = "Move &down";
            this.btnFieldIndDown.UseVisualStyleBackColor = true;
            this.btnFieldIndDown.Click += new System.EventHandler(this.btnFieldIndDown_Click);
            // 
            // btnFieldIndUp
            // 
            this.btnFieldIndUp.Location = new System.Drawing.Point(288, 65);
            this.btnFieldIndUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFieldIndUp.Name = "btnFieldIndUp";
            this.btnFieldIndUp.Size = new System.Drawing.Size(112, 35);
            this.btnFieldIndUp.TabIndex = 2;
            this.btnFieldIndUp.Text = "Move &up";
            this.btnFieldIndUp.UseVisualStyleBackColor = true;
            this.btnFieldIndUp.Click += new System.EventHandler(this.btnFieldIndUp_Click);
            // 
            // lstFieldsInd
            // 
            this.lstFieldsInd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstFieldsInd.FormattingEnabled = true;
            this.lstFieldsInd.Location = new System.Drawing.Point(9, 65);
            this.lstFieldsInd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstFieldsInd.Name = "lstFieldsInd";
            this.lstFieldsInd.Size = new System.Drawing.Size(268, 211);
            this.lstFieldsInd.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editAdditionalPropertiesToolStripMenuItem,
            this.openContainingFolderToolStripMenuItem,
            this.renameSeriesToolStripMenuItem,
            this.openSeriesInNTPlatformAppToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(336, 132);
            // 
            // editAdditionalPropertiesToolStripMenuItem
            // 
            this.editAdditionalPropertiesToolStripMenuItem.Name = "editAdditionalPropertiesToolStripMenuItem";
            this.editAdditionalPropertiesToolStripMenuItem.Size = new System.Drawing.Size(335, 32);
            this.editAdditionalPropertiesToolStripMenuItem.Text = "Edit additional properties";
            this.editAdditionalPropertiesToolStripMenuItem.Click += new System.EventHandler(this.editAdditionalPropertiesToolStripMenuItem_Click);
            // 
            // openContainingFolderToolStripMenuItem
            // 
            this.openContainingFolderToolStripMenuItem.Name = "openContainingFolderToolStripMenuItem";
            this.openContainingFolderToolStripMenuItem.Size = new System.Drawing.Size(335, 32);
            this.openContainingFolderToolStripMenuItem.Text = "Open containing folder";
            this.openContainingFolderToolStripMenuItem.Click += new System.EventHandler(this.openContainingFolderToolStripMenuItem_Click);
            // 
            // renameSeriesToolStripMenuItem
            // 
            this.renameSeriesToolStripMenuItem.Name = "renameSeriesToolStripMenuItem";
            this.renameSeriesToolStripMenuItem.Size = new System.Drawing.Size(335, 32);
            this.renameSeriesToolStripMenuItem.Text = "Rename series";
            this.renameSeriesToolStripMenuItem.Click += new System.EventHandler(this.renameSeriesToolStripMenuItem_Click);
            // 
            // openSeriesInNTPlatformAppToolStripMenuItem
            // 
            this.openSeriesInNTPlatformAppToolStripMenuItem.Name = "openSeriesInNTPlatformAppToolStripMenuItem";
            this.openSeriesInNTPlatformAppToolStripMenuItem.Size = new System.Drawing.Size(335, 32);
            this.openSeriesInNTPlatformAppToolStripMenuItem.Text = "Open series in NT Platform App";
            this.openSeriesInNTPlatformAppToolStripMenuItem.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsProgressBarLabel,
            this.tsProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 496);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(870, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsProgressBarLabel
            // 
            this.tsProgressBarLabel.Name = "tsProgressBarLabel";
            this.tsProgressBarLabel.Size = new System.Drawing.Size(85, 25);
            this.tsProgressBarLabel.Text = "Progress:";
            this.tsProgressBarLabel.Visible = false;
            // 
            // tsProgressBar
            // 
            this.tsProgressBar.Name = "tsProgressBar";
            this.tsProgressBar.Size = new System.Drawing.Size(150, 22);
            this.tsProgressBar.Visible = false;
            // 
            // MainForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Application;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 518);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.txtExportPath);
            this.Controls.Add(this.btnExportBrowse);
            this.Controls.Add(this.optExportToAnotherPath);
            this.Controls.Add(this.optExportToSamePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnExportAvg);
            this.Controls.Add(this.btnExportInd);
            this.Controls.Add(this.chkRecursive);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtInputPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "NTP3 Analysis Export";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.tabControlMain.ResumeLayout(false);
            this.tabExperiments.ResumeLayout(false);
            this.tabDisplaySettings.ResumeLayout(false);
            this.tabDisplaySettings.PerformLayout();
            this.tabExportSettings.ResumeLayout(false);
            this.tabExportSettings.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInputPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.CheckBox chkRecursive;
        private System.Windows.Forms.Button btnExportInd;
        private System.Windows.Forms.Button btnExportAvg;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton optExportToSamePath;
        private System.Windows.Forms.RadioButton optExportToAnotherPath;
        private System.Windows.Forms.Button btnExportBrowse;
        private System.Windows.Forms.TextBox txtExportPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabExperiments;
        private System.Windows.Forms.ListView lstSeries;
        private System.Windows.Forms.TabPage tabExportSettings;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editAdditionalPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openContainingFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameSeriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSeriesInNTPlatformAppToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsProgressBarLabel;
        private System.Windows.Forms.ToolStripProgressBar tsProgressBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFieldAvgDown;
        private System.Windows.Forms.Button btnFieldAvgUp;
        private System.Windows.Forms.CheckedListBox lstFieldsAvg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFieldIndDown;
        private System.Windows.Forms.Button btnFieldIndUp;
        private System.Windows.Forms.CheckedListBox lstFieldsInd;
        private System.Windows.Forms.TabPage tabDisplaySettings;
        private System.Windows.Forms.CheckBox chkHideSampleNameFromSeriesName;
        private System.Windows.Forms.CheckBox chkExportOnlyLastModified;
    }
}
