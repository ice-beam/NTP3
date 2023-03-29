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
    partial class ErrorForm
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ErrorForm));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtErrorMessage = new TextBox();
            label2 = new Label();
            btnReport = new Button();
            btnClose = new Button();
            ((ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(39, 38);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            label1.AutoSize = true;
            label1.Location = new Point(58, 12);
            label1.Name = "label1";
            label1.Size = new Size(279, 13);
            label1.TabIndex = 1;
            label1.Text = "The following error occured during the software operation:";
            txtErrorMessage.Location = new Point(61, 29);
            txtErrorMessage.Multiline = true;
            txtErrorMessage.Name = "txtErrorMessage";
            txtErrorMessage.ReadOnly = true;
            txtErrorMessage.ScrollBars = ScrollBars.Vertical;
            txtErrorMessage.Size = new Size(425, 107);
            txtErrorMessage.TabIndex = 2;
            label2.AutoSize = true;
            label2.Location = new Point(58, 148);
            label2.Name = "label2";
            label2.Size = new Size(323, 13);
            label2.TabIndex = 3;
            label2.Text = "Please report this error message to the software author. Thank you.";
            btnReport.Location = new Point(330, 169);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(75, 23);
            btnReport.TabIndex = 4;
            btnReport.Text = "Report";
            btnReport.UseVisualStyleBackColor = true;
            btnReport.Click += new EventHandler(btnReport_Click);
            btnClose.DialogResult = DialogResult.OK;
            btnClose.Location = new Point(411, 169);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            AcceptButton = btnClose;
            AccessibleRole = AccessibleRole.TitleBar;
            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(498, 205);
            Controls.Add(btnClose);
            Controls.Add(btnReport);
            Controls.Add(label2);
            Controls.Add(txtErrorMessage);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ErrorForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Error";
            ((ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
