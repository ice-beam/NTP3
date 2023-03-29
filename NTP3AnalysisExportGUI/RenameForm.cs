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
using NTP3.Utils;

namespace NTP3AnalysisExportGUI
{
    public partial class RenameForm : Form
    {
        private string oldFileName = "";
        private string newFileName = "";

        public RenameForm() => InitializeComponent();

        public void SetFolderName(string value) => txtFolderName.Text = value;

        public void SetOldFileName(string value)
        {
            txtOldFileName.Text = value;
            oldFileName = value;
            txtNewFileName.Text = value;
            newFileName = value;
        }

        public string GetNewFileName() => newFileName;

        private void btnOK_Click(object sender, EventArgs e)
        {
            string testName = txtNewFileName.Text.Trim();
            if (testName.Length == 0)
            {
                MessageBox.Show(this, "File name cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (!FileUtils.IsValidFileName(testName))
            {
                MessageBox.Show(this, "File name must not contain invalid characters", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                newFileName = testName;
                if (testName == oldFileName)
                    DialogResult = DialogResult.Cancel;
                else
                    DialogResult = DialogResult.OK;
            }
        }
    }
}
