/*
    NTP3Utils
    Copyright (C) 2020-2023 boris.mitrin@gmail.com

    Permission is hereby granted, free of charge, to any person obtaining
    a copy of this software and associated documentation files 
    (the "Software"), to deal in the Software without restriction, including
    without limitation therights to use, copy, modify, merge, publish,
    distribute, sublicense, and/or sell copies of the Software, and to permit
    persons to whom the Software is furnished to do so, subject to
    the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
    FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
    DEALINGS IN THE SOFTWARE.
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
