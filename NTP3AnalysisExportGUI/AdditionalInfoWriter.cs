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
using System.Globalization;
using System.IO;
using NTP3.DI;
using NTP3.Interfaces;

namespace NTP3
{
    public class AdditionalInfoWriter
    {
        public static IIniFileFactory IniFileFactory = DependencyContainer.GetInstance<IIniFileFactory>();

        private void WriteStatedString(IIniFile iniFile, string section, string name, string value)
        {
            if (AdditionalInfo.IsVariety(value))
                return;
            if (AdditionalInfo.IsEmpty(value))
                iniFile.DeleteKey(name, section);
            else
                iniFile.Write(name, value, section);
        }

        private void WriteStatedFloat(
            IIniFile iniFile,
            string section,
            string name,
            float value,
            string format)
        {
            if (AdditionalInfo.IsVariety(value))
                return;
            if (AdditionalInfo.IsEmpty(value))
                iniFile.DeleteKey(name, section);
            else
                iniFile.Write(name, value.ToString(format, CultureInfo.InvariantCulture), section);
        }

        private void WriteAdditionalInfoToIniFile(IIniFile iniFile, AdditionalInfo info)
        {
            WriteStatedString(iniFile, "Sample", "Name", info.SampleName);
            WriteStatedFloat(iniFile, "Sample", "nu", info.Nu, "F3");
            WriteStatedString(iniFile, "Accounting", "Operator", info.OperatorName);
            WriteStatedString(iniFile, "Accounting", "Order", info.OrderNumber);
        }

        private bool IsInfoNotChanged(AdditionalInfo info) => info.Variety;

        private bool IsInfoEmpty(AdditionalInfo info) => info.Empty;

        private void WriteAdditionalInfo(AdditionalInfo info, string fileFullPath)
        {
            if (IsInfoNotChanged(info) || IsInfoEmpty(info) && !File.Exists(fileFullPath))
                return;
            WriteAdditionalInfoToIniFile(IniFileFactory.Create(fileFullPath), info);
        }

        public void WriteFolderAdditionalInfo(AdditionalInfo info, string filePath, string fileName)
        {
            string fileFullPath = filePath + "\\_nt.ini";
            WriteAdditionalInfo(info, fileFullPath);
        }

        public void WriteFileAdditionalInfo(AdditionalInfo info, string filePath, string fileName)
        {
            string fileFullPath = filePath + "\\" + fileName + ".ini";
            WriteAdditionalInfo(info, fileFullPath);
        }

        public AdditionalInfo ApplyAdditionalInfo(
          AdditionalInfo oldInfo,
          AdditionalInfo newInfo)
        {
            if (!AdditionalInfo.IsVariety(newInfo.SampleName))
                oldInfo.SampleName = newInfo.SampleName;
            if (!AdditionalInfo.IsVariety(newInfo.OperatorName))
                oldInfo.OperatorName = newInfo.OperatorName;
            if (!AdditionalInfo.IsVariety(newInfo.OrderNumber))
                oldInfo.OrderNumber = newInfo.OrderNumber;
            if (!AdditionalInfo.IsVariety(newInfo.Nu))
                oldInfo.Nu = newInfo.Nu;
            return oldInfo;
        }
    }
}
