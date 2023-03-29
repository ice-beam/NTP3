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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NTP3AnalysisExportGUI
{
    partial class ParametersForm
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtFolderName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            cmbFolderSampleName = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            cmbFolderOperatorName = new ComboBox();
            cmbFileSampleName = new ComboBox();
            cmbFileOperatorName = new ComboBox();
            cmbFileOrderName = new ComboBox();
            cmbFolderOrderName = new ComboBox();
            label5 = new Label();
            btnOk = new Button();
            btnCancel = new Button();
            chkFolderSampleName = new CheckBox();
            txtFileName = new TextBox();
            chkFolderOperatorName = new CheckBox();
            chkFolderOrderName = new CheckBox();
            chkFileOrderName = new CheckBox();
            chkFileOperatorName = new CheckBox();
            chkFileSampleName = new CheckBox();
            label6 = new Label();
            label7 = new Label();
            chkFileNu = new CheckBox();
            chkFolderNu = new CheckBox();
            label8 = new Label();
            txtFolderNu = new TextBox();
            txtFileNu = new TextBox();
            SuspendLayout();
            txtFolderName.Location = new Point(57, 12);
            txtFolderName.Name = "txtFolderName";
            txtFolderName.ReadOnly = true;
            txtFolderName.Size = new Size(335, 20);
            txtFolderName.TabIndex = 1;
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(39, 13);
            label1.TabIndex = 0;
            label1.Text = "Folder:";
            label2.AutoSize = true;
            label2.Location = new Point(12, 41);
            label2.Name = "label2";
            label2.Size = new Size(26, 13);
            label2.TabIndex = 2;
            label2.Text = "File:";
            cmbFolderSampleName.FormattingEnabled = true;
            cmbFolderSampleName.Location = new Point(113, 91);
            cmbFolderSampleName.Name = "cmbFolderSampleName";
            cmbFolderSampleName.Size = new Size(126, 21);
            cmbFolderSampleName.TabIndex = 6;
            label3.AutoSize = true;
            label3.Location = new Point(12, 95);
            label3.Name = "label3";
            label3.Size = new Size(74, 13);
            label3.TabIndex = 4;
            label3.Text = "Sample name:";
            label4.AutoSize = true;
            label4.Location = new Point(12, 122);
            label4.Name = "label4";
            label4.Size = new Size(80, 13);
            label4.TabIndex = 9;
            label4.Text = "Operator name:";
            cmbFolderOperatorName.FormattingEnabled = true;
            cmbFolderOperatorName.Location = new Point(113, 118);
            cmbFolderOperatorName.Name = "cmbFolderOperatorName";
            cmbFolderOperatorName.Size = new Size(126, 21);
            cmbFolderOperatorName.TabIndex = 11;
            cmbFileSampleName.FormattingEnabled = true;
            cmbFileSampleName.Location = new Point(265, 91);
            cmbFileSampleName.Name = "cmbFileSampleName";
            cmbFileSampleName.Size = new Size(sbyte.MaxValue, 21);
            cmbFileSampleName.TabIndex = 8;
            cmbFileOperatorName.FormattingEnabled = true;
            cmbFileOperatorName.Location = new Point(265, 119);
            cmbFileOperatorName.Name = "cmbFileOperatorName";
            cmbFileOperatorName.Size = new Size(sbyte.MaxValue, 21);
            cmbFileOperatorName.TabIndex = 13;
            cmbFileOrderName.FormattingEnabled = true;
            cmbFileOrderName.Location = new Point(265, 146);
            cmbFileOrderName.Name = "cmbFileOrderName";
            cmbFileOrderName.Size = new Size(sbyte.MaxValue, 21);
            cmbFileOrderName.TabIndex = 18;
            cmbFolderOrderName.FormattingEnabled = true;
            cmbFolderOrderName.Location = new Point(113, 145);
            cmbFolderOrderName.Name = "cmbFolderOrderName";
            cmbFolderOrderName.Size = new Size(126, 21);
            cmbFolderOrderName.TabIndex = 16;
            label5.AutoSize = true;
            label5.Location = new Point(12, 149);
            label5.Name = "label5";
            label5.Size = new Size(65, 13);
            label5.TabIndex = 14;
            label5.Text = "Order name:";
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(236, 210);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 20;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(317, 210);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 19;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            chkFolderSampleName.AutoSize = true;
            chkFolderSampleName.Location = new Point(92, 94);
            chkFolderSampleName.Name = "chkFolderSampleName";
            chkFolderSampleName.Size = new Size(15, 14);
            chkFolderSampleName.TabIndex = 5;
            chkFolderSampleName.UseVisualStyleBackColor = true;
            chkFolderSampleName.CheckedChanged += new EventHandler(chkFolderSampleName_CheckedChanged);
            txtFileName.Location = new Point(57, 38);
            txtFileName.Name = "txtFileName";
            txtFileName.ReadOnly = true;
            txtFileName.Size = new Size(335, 20);
            txtFileName.TabIndex = 3;
            chkFolderOperatorName.AutoSize = true;
            chkFolderOperatorName.Location = new Point(92, 121);
            chkFolderOperatorName.Name = "chkFolderOperatorName";
            chkFolderOperatorName.Size = new Size(15, 14);
            chkFolderOperatorName.TabIndex = 10;
            chkFolderOperatorName.UseVisualStyleBackColor = true;
            chkFolderOperatorName.CheckedChanged += new EventHandler(chkFolderOperatorName_CheckedChanged);
            chkFolderOrderName.AutoSize = true;
            chkFolderOrderName.Location = new Point(92, 148);
            chkFolderOrderName.Name = "chkFolderOrderName";
            chkFolderOrderName.Size = new Size(15, 14);
            chkFolderOrderName.TabIndex = 15;
            chkFolderOrderName.UseVisualStyleBackColor = true;
            chkFolderOrderName.CheckedChanged += new EventHandler(chkFolderOrderName_CheckedChanged);
            chkFileOrderName.AutoSize = true;
            chkFileOrderName.Location = new Point(245, 148);
            chkFileOrderName.Name = "chkFileOrderName";
            chkFileOrderName.Size = new Size(15, 14);
            chkFileOrderName.TabIndex = 17;
            chkFileOrderName.UseVisualStyleBackColor = true;
            chkFileOrderName.CheckedChanged += new EventHandler(chkFileOrderName_CheckedChanged);
            chkFileOperatorName.AutoSize = true;
            chkFileOperatorName.Location = new Point(245, 121);
            chkFileOperatorName.Name = "chkFileOperatorName";
            chkFileOperatorName.Size = new Size(15, 14);
            chkFileOperatorName.TabIndex = 12;
            chkFileOperatorName.UseVisualStyleBackColor = true;
            chkFileOperatorName.CheckedChanged += new EventHandler(chkFileOperatorName_CheckedChanged);
            chkFileSampleName.AutoSize = true;
            chkFileSampleName.Location = new Point(245, 94);
            chkFileSampleName.Name = "chkFileSampleName";
            chkFileSampleName.Size = new Size(15, 14);
            chkFileSampleName.TabIndex = 7;
            chkFileSampleName.UseVisualStyleBackColor = true;
            chkFileSampleName.CheckedChanged += new EventHandler(chkFileSampleName_CheckedChanged);
            label6.AutoSize = true;
            label6.Location = new Point(113, 68);
            label6.Name = "label6";
            label6.Size = new Size(80, 13);
            label6.TabIndex = 21;
            label6.Text = "Folder property:";
            label7.AutoSize = true;
            label7.Location = new Point(262, 68);
            label7.Name = "label7";
            label7.Size = new Size(67, 13);
            label7.TabIndex = 22;
            label7.Text = "File property:";
            chkFileNu.AutoSize = true;
            chkFileNu.Location = new Point(245, 177);
            chkFileNu.Name = "chkFileNu";
            chkFileNu.Size = new Size(15, 14);
            chkFileNu.TabIndex = 26;
            chkFileNu.UseVisualStyleBackColor = true;
            chkFileNu.CheckedChanged += new EventHandler(chkFileNu_CheckedChanged);
            chkFolderNu.AutoSize = true;
            chkFolderNu.Location = new Point(92, 175);
            chkFolderNu.Name = "chkFolderNu";
            chkFolderNu.Size = new Size(15, 14);
            chkFolderNu.TabIndex = 24;
            chkFolderNu.UseVisualStyleBackColor = true;
            chkFolderNu.CheckedChanged += new EventHandler(chkFolderNu_CheckedChanged);
            label8.AutoSize = true;
            label8.Location = new Point(12, 176);
            label8.Name = "label8";
            label8.Size = new Size(77, 13);
            label8.TabIndex = 23;
            label8.Text = "Poisson's ratio:";
            txtFolderNu.Location = new Point(113, 173);
            txtFolderNu.Name = "txtFolderNu";
            txtFolderNu.Size = new Size(126, 20);
            txtFolderNu.TabIndex = 27;
            txtFileNu.Location = new Point(265, 173);
            txtFileNu.Name = "txtFileNu";
            txtFileNu.Size = new Size(sbyte.MaxValue, 20);
            txtFileNu.TabIndex = 28;
            AcceptButton = btnOk;
            AccessibleRole = AccessibleRole.TitleBar;
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(406, 245);
            Controls.Add(txtFileNu);
            Controls.Add(txtFolderNu);
            Controls.Add(chkFileNu);
            Controls.Add(chkFolderNu);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(chkFileOrderName);
            Controls.Add(chkFileOperatorName);
            Controls.Add(chkFileSampleName);
            Controls.Add(chkFolderOrderName);
            Controls.Add(chkFolderOperatorName);
            Controls.Add(txtFileName);
            Controls.Add(chkFolderSampleName);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(cmbFileOrderName);
            Controls.Add(cmbFolderOrderName);
            Controls.Add(label5);
            Controls.Add(cmbFileOperatorName);
            Controls.Add(cmbFileSampleName);
            Controls.Add(cmbFolderOperatorName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cmbFolderSampleName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtFolderName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ParametersForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Additional properties";
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtFolderName;
        private Label label1;
        private Label label2;
        private ComboBox cmbFolderSampleName;
        private Label label3;
        private Label label4;
        private ComboBox cmbFolderOperatorName;
        private ComboBox cmbFileSampleName;
        private ComboBox cmbFileOperatorName;
        private ComboBox cmbFileOrderName;
        private ComboBox cmbFolderOrderName;
        private Label label5;
        private Button btnOk;
        private Button btnCancel;
        private CheckBox chkFolderSampleName;
        private TextBox txtFileName;
        private CheckBox chkFolderOperatorName;
        private CheckBox chkFolderOrderName;
        private CheckBox chkFileOrderName;
        private CheckBox chkFileOperatorName;
        private CheckBox chkFileSampleName;
        private Label label6;
        private Label label7;
        private CheckBox chkFileNu;
        private CheckBox chkFolderNu;
        private Label label8;
        private TextBox txtFolderNu;
        private TextBox txtFileNu;

    }
}
