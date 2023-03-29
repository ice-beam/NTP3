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
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using NTP3.Interfaces;

namespace NTP3.Utils
{
    /// <summary>
    /// Tiny class for reading/writing ini files using Win32 API.
    /// Inspired by https://github.com/niklyadov/tiny-ini-file-class
    /// </summary>
    public class IniFile : IIniFile
    {
        private readonly string exe;
        private readonly string path;
        
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(
          string section,
          string key,
          string value,
          string filePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(
          string section,
          string key,
          string @default,
          StringBuilder retVal,
          int size,
          string filePath);

        public IniFile(string iniPath = null)
        {
            exe = Assembly.GetExecutingAssembly().GetName().Name;
            path = new FileInfo(iniPath ?? exe + ".ini").FullName;
        }

        public string Read(string key, string section = null)
        {
            StringBuilder RetVal = new StringBuilder(byte.MaxValue);
            GetPrivateProfileString(section ?? exe, key, "", RetVal, byte.MaxValue, path);
            return RetVal.ToString();
        }

        public void Write(string key, string value, string section = null) => WritePrivateProfileString(section ?? exe, key, value, path);

        public void DeleteKey(string key, string section = null) => Write(key, null, section ?? exe);

        public void DeleteSection(string section = null) => Write(null, null, section ?? exe);

        public bool KeyExists(string key, string section = null) => Read(key, section).Length > 0;
    }
}
