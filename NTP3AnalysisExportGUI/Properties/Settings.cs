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
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NTP3AnalysisExportGUI.Properties
{
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
  [CompilerGenerated]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default => Settings.defaultInstance;

    [DefaultSettingValue("")]
    [UserScopedSetting]
    [DebuggerNonUserCode]
    public string InputPath
    {
      get => (string) this[nameof (InputPath)];
      set => this[nameof (InputPath)] = (object) value;
    }

    [DefaultSettingValue("False")]
    [DebuggerNonUserCode]
    [UserScopedSetting]
    public bool InputRecursive
    {
      get => (bool) this[nameof (InputRecursive)];
      set => this[nameof (InputRecursive)] = (object) value;
    }

    [DefaultSettingValue("")]
    [UserScopedSetting]
    [DebuggerNonUserCode]
    public string ExportPath
    {
      get => (string) this[nameof (ExportPath)];
      set => this[nameof (ExportPath)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ExportToSamePath
    {
      get => (bool) this[nameof (ExportToSamePath)];
      set => this[nameof (ExportToSamePath)] = (object) value;
    }

    [UserScopedSetting]
    [DefaultSettingValue("False")]
    [DebuggerNonUserCode]
    public bool HideSampleNameFromSeriesName
    {
      get => (bool) this[nameof (HideSampleNameFromSeriesName)];
      set => this[nameof (HideSampleNameFromSeriesName)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string ExportFieldsIndOrder
    {
      get => (string) this[nameof (ExportFieldsIndOrder)];
      set => this[nameof (ExportFieldsIndOrder)] = (object) value;
    }

    [DebuggerNonUserCode]
    [UserScopedSetting]
    [DefaultSettingValue("SeriesName,Pmax,hmax,hc,C,H,Er,FitMSE,PLF:a,PLF:hp,PLF:m")]
    public string ExportFieldsIndSelected
    {
      get => (string) this[nameof (ExportFieldsIndSelected)];
      set => this[nameof (ExportFieldsIndSelected)] = (object) value;
    }

    [DefaultSettingValue("")]
    [DebuggerNonUserCode]
    [UserScopedSetting]
    public string ExportFieldsAvgOrder
    {
      get => (string) this[nameof (ExportFieldsAvgOrder)];
      set => this[nameof (ExportFieldsAvgOrder)] = (object) value;
    }

    [DebuggerNonUserCode]
    [DefaultSettingValue("SeriesName,Pmax,hmax,hc,C,H,Er,SD:Er")]
    [UserScopedSetting]
    public string ExportFieldsAvgSelected
    {
      get => (string) this[nameof (ExportFieldsAvgSelected)];
      set => this[nameof (ExportFieldsAvgSelected)] = (object) value;
    }

    [UserScopedSetting]
    [DefaultSettingValue("False")]
    [DebuggerNonUserCode]
    public bool ExportOnlyLastModified
    {
      get => (bool) this[nameof (ExportOnlyLastModified)];
      set => this[nameof (ExportOnlyLastModified)] = (object) value;
    }

    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    [UserScopedSetting]
    public string WindowLocaton
    {
      get => (string) this[nameof (WindowLocaton)];
      set => this[nameof (WindowLocaton)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string WindowSize
    {
      get => (string) this[nameof (WindowSize)];
      set => this[nameof (WindowSize)] = (object) value;
    }
  }
}
