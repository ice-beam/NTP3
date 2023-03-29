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
using System.Diagnostics;
using System.Windows.Forms;

namespace NTP3AnalysisExportGUI
{
    public partial class ErrorForm : Form
    {
        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txtErrorMessage;
        private Label label2;
        private Button btnReport;
        private Button btnClose;
        private string cause;

        public ErrorForm() => InitializeComponent();

        public void SetErrorMessage(string text) => txtErrorMessage.Text = text;

        public void SetCause(string text) => cause = text;

        private void btnReport_Click(object sender, EventArgs e)
        {
            string str1 = "boris.mitrin@gmail.com";
            string stringToEscape1 = "Error in NTP3AnalysisExport";
            string str2 = "Dear Boris,\r\nI have encountered a problem in using NTP3AnalysisExport software.\r\nWhen I operated this software (please specify what you did),\r\nI had the following error message displayed:\n\n" + txtErrorMessage.Text + "\n\n";
            if (cause != null)
                str2 = str2 + "This occured when " + cause + "\n\n";
            string stringToEscape2 = str2 + "Best regards,\n\n";
            Process.Start("mailto:" + str1 + "?subject=" + Uri.EscapeUriString(stringToEscape1) + "&body=" + Uri.EscapeUriString(stringToEscape2));
        }
    }
}
