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
    partial class RenameForm
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
            txtOldFileName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtFolderName = new TextBox();
            txtNewFileName = new TextBox();
            label3 = new Label();
            btnCancel = new Button();
            btnOK = new Button();
            SuspendLayout();
            txtOldFileName.Location = new Point(109, 37);
            txtOldFileName.Name = "txtOldFileName";
            txtOldFileName.ReadOnly = true;
            txtOldFileName.Size = new Size(283, 20);
            txtOldFileName.TabIndex = 7;
            label2.AutoSize = true;
            label2.Location = new Point(12, 40);
            label2.Name = "label2";
            label2.Size = new Size(85, 13);
            label2.TabIndex = 6;
            label2.Text = "Old series name:";
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(39, 13);
            label1.TabIndex = 4;
            label1.Text = "Folder:";
            txtFolderName.Location = new Point(57, 11);
            txtFolderName.Name = "txtFolderName";
            txtFolderName.ReadOnly = true;
            txtFolderName.Size = new Size(335, 20);
            txtFolderName.TabIndex = 5;
            txtNewFileName.Location = new Point(109, 63);
            txtNewFileName.Name = "txtNewFileName";
            txtNewFileName.Size = new Size(283, 20);
            txtNewFileName.TabIndex = 1;
            label3.AutoSize = true;
            label3.Location = new Point(11, 66);
            label3.Name = "label3";
            label3.Size = new Size(91, 13);
            label3.TabIndex = 0;
            label3.Text = "New series name:";
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(317, 99);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnOK.Location = new Point(236, 99);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 3;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += new EventHandler(btnOK_Click);
            AcceptButton = btnOK;
            AccessibleRole = AccessibleRole.TitleBar;
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(404, 134);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            Controls.Add(txtNewFileName);
            Controls.Add(label3);
            Controls.Add(txtOldFileName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtFolderName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RenameForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Rename series";
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtOldFileName;
        private Label label2;
        private Label label1;
        private TextBox txtFolderName;
        private TextBox txtNewFileName;
        private Label label3;
        private Button btnCancel;
        private Button btnOK;
    }
}
