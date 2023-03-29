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
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using NTP3.DI;
using NTP3.Interfaces;
using NTP3.Utils;

namespace NTP3
{
    public class AnalysisResultReader : IEnumerable
    {
        public static IIniFileFactory IniFileFactory = DependencyContainer.GetInstance<IIniFileFactory>();

        public int Length => indentationSeriesArray.Length;
        public int SeriesCount => indentationSeriesArray.Length;
        public int CurvesCount => analysisResultsArray.Length;
        public event EventHandler PathLookupStarted;
        public event EventHandler PathLookupFinished;
        public event EventHandler PathReadingFinished;
        public event EventHandler<AnalysisReadingEventArgs> SeriesReadingFinished;
        public IndentationSeriesRecord this[int i] => indentationSeriesArray[i];
        
        private AnalysisResultRecord[] analysisResultsArray;
        private IndentationSeriesRecord[] indentationSeriesArray;

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Length; ++i)
                yield return indentationSeriesArray[i];
        }

        public void ReplaceSeries(int seriesIndex, IndentationSeriesRecord record) => indentationSeriesArray[seriesIndex] = record;

        public void InvalidateSeries(int seriesIndex)
        {
            string folderName = indentationSeriesArray[seriesIndex].FolderName;
            string seriesName = indentationSeriesArray[seriesIndex].SeriesName;
            int si = seriesIndex;
            int firstCurveIndex = indentationSeriesArray[seriesIndex].FirstCurveIndex;
            AdditionalInfo directoryInfo = ReadAdditionalInfo(GetDirectoryAdditionalInfoFullFileName(folderName));
            ReadFile(folderName, seriesName, ref si, ref firstCurveIndex, directoryInfo);
        }

        public void ReadAllFilesAtPath(string path, bool recursive)
        {
            int totalCurvesCount = 0;
            int totalSeriesCount = 0;
            PathLookupStarted?.Invoke(this, EventArgs.Empty);
            IterateFilesAtPath(path, recursive, (_path, _seriesName, _directoryInfo) =>
            {
                totalCurvesCount += GetCurvesCount(_path, _seriesName);
                ++totalSeriesCount;
            });
            analysisResultsArray = new AnalysisResultRecord[totalCurvesCount];
            indentationSeriesArray = new IndentationSeriesRecord[totalSeriesCount];
            PathLookupFinished?.Invoke(this, EventArgs.Empty);
            int si = 0;
            int i = 0;
            IterateFilesAtPath(path, recursive, (_path, _seriesName, _directoryInfo) =>
            {
                int num = i;
                int seriesIndex = si;
                ReadFile(_path, _seriesName, ref si, ref i, _directoryInfo);
                SeriesReadingFinished?.Invoke(this, new AnalysisReadingEventArgs(seriesIndex, i - num - 1));
            });
            List<int> source = new List<int>();
            for (si = 0; si < indentationSeriesArray.Length; ++si)
            {
                if (!indentationSeriesArray[si].IsModified)
                {
                    string str = indentationSeriesArray[si].FullFileName + " ";
                    source.Clear();
                    for (int index = 0; index < indentationSeriesArray.Length; ++index)
                    {
                        if (indentationSeriesArray[index].FullFileName.StartsWith(str))
                            source.Add(index);
                    }
                    if (source.Count == 0)
                    {
                        indentationSeriesArray[si].OriginalSeriesNo = si;
                        indentationSeriesArray[si].LastModifiedSeriesNo = si;
                    }
                    else
                    {
                        DateTime lastModifiedDateTime = source.Max(si2 => indentationSeriesArray[si2].ExperimentAnalysedLast);
                        int num = source.First(si2 => indentationSeriesArray[si2].ExperimentAnalysedLast == lastModifiedDateTime);
                        indentationSeriesArray[si].OriginalSeriesNo = si;
                        indentationSeriesArray[si].LastModifiedSeriesNo = num;
                        foreach (int index in source)
                        {
                            indentationSeriesArray[index].OriginalSeriesNo = si;
                            indentationSeriesArray[index].ExperimentScheduled = indentationSeriesArray[si].ExperimentScheduled;
                            indentationSeriesArray[index].ExperimentStarted = indentationSeriesArray[si].ExperimentStarted;
                            indentationSeriesArray[index].ExperimentFinished = indentationSeriesArray[si].ExperimentFinished;
                            indentationSeriesArray[index].LastModifiedSeriesNo = num;
                        }
                    }
                }
            }
            Array.Sort(analysisResultsArray, new AnalysisResultRecordComparer());
            PathReadingFinished?.Invoke(this, EventArgs.Empty);
        }

        public void WriteAnalysisResultsToStream(StreamWriter osw)
        {
            WriteColumnsToStream(osw);
            WriteAllSeriesToStream(osw);
        }

        public void WriteColumnsToStream(StreamWriter osw) => WriteColumnsToStream(osw, AnalysisExportColumnSpecification.DefaultSet);
        public void WriteColumnsToStream(StreamWriter osw, IEnumerable<AnalysisExportColumnSpecification> columns)
        {
            IEnumerable<string> strings = columns.Select(column => column.DisplayName + (column.Unit.Length > 0 ? $", {column.Unit}" : ""));
            osw.WriteLine(string.Join("\t", strings));
        }

        public void WriteAllSeriesToStream(StreamWriter osw) => WriteAllSeriesToStream(osw, AnalysisExportColumnSpecification.DefaultSet);
        public void WriteAllSeriesToStream(StreamWriter osw, IEnumerable<AnalysisExportColumnSpecification> columns)
        {
            for (int k = 0; k < analysisResultsArray.Length; ++k)
            {
                if (indentationSeriesArray[analysisResultsArray[k].SeriesNo].IsExperimentAnalysed)
                {
                    int k1 = k;
                    IEnumerable<string> strings = columns.Select(column => AnalysisResultsFormatter.Format(analysisResultsArray[k1], indentationSeriesArray[analysisResultsArray[k1].SeriesNo], column.Column));
                    osw.WriteLine(string.Join("\t", strings));
                }
            }
        }

        public void WriteSeriesToStream(StreamWriter osw, int seriesNo) => WriteSeriesToStream(osw, seriesNo, AnalysisExportColumnSpecification.DefaultSet);
        public void WriteSeriesToStream(StreamWriter osw, int seriesNo, IEnumerable<AnalysisExportColumnSpecification> columns)
        {
            if (!indentationSeriesArray[seriesNo].IsExperimentAnalysed)
                return;
            for (int k = 0; k < analysisResultsArray.Length; ++k)
            {
                if (analysisResultsArray[k].SeriesNo == seriesNo)
                {
                    IEnumerable<string> strings = columns.Select(column => AnalysisResultsFormatter.Format(analysisResultsArray[k], indentationSeriesArray[seriesNo], column.Column));
                    osw.WriteLine(string.Join("\t", strings));
                }
            }
        }

        public void WriteSeriesAvgToStream(StreamWriter osw, int seriesNo) => WriteSeriesAvgToStream(osw, seriesNo, AnalysisExportColumnSpecification.DefaultAvgSet);
        public void WriteSeriesAvgToStream(StreamWriter osw, int seriesNo, IEnumerable<AnalysisExportColumnSpecification> columns)
        {
            if (!indentationSeriesArray[seriesNo].IsExperimentAnalysed)
                return;
            AnalysisResult sum = new AnalysisResult();
            int sk = -1;
            int num = 0;
            for (int index = 0; index < analysisResultsArray.Length; ++index)
            {
                if (analysisResultsArray[index].SeriesNo == seriesNo)
                {
                    sk = index;
                    sum += analysisResultsArray[index].Result;
                    ++num;
                }
            }
            if (sk < 0)
                return;
            AnalysisResult avg = sum / num;
            AnalysisResult tmp = new AnalysisResult();
            for (int index = 0; index < analysisResultsArray.Length; ++index)
            {
                if (analysisResultsArray[index].SeriesNo == seriesNo)
                {
                    AnalysisResult diff = analysisResultsArray[index].Result - avg;
                    tmp += diff * diff;
                }
            }
            AnalysisResultRecord stdev = analysisResultsArray[sk];
            stdev.Result = (tmp / (num - 1)).Sqrt();
            IEnumerable<string> strings = columns.Select(column => column.AverageOnly ? AnalysisResultsFormatter.Format(stdev, indentationSeriesArray[seriesNo], column.Column) : AnalysisResultsFormatter.Format(analysisResultsArray[sk], indentationSeriesArray[seriesNo], column.Column));
            osw.WriteLine(string.Join("\t", strings));
        }

        private static void ReadIndentationSeries(string path, string seriesName, ref IndentationSeriesRecord rec)
        {
            string str = $@"{path}\{seriesName}";
            using (FileStream input = new FileStream(str + ".ind", FileMode.Open))
            {
                using (BinaryReader binaryReader = new BinaryReader(input))
                {
                    rec.FolderName = path;
                    rec.SeriesName = seriesName;
                    rec.FullFileName = str;
                    FileInfo fileInfo1 = new FileInfo(str + ".ind");
                    FileInfo fileInfo2 = new FileInfo(str + ".idt");
                    FileInfo fileInfo3 = new FileInfo(str + ".ipf");
                    FileInfo fileInfo4 = new FileInfo(str + ".pft");
                    rec.ExperimentScheduled = fileInfo1.CreationTime;
                    if (!fileInfo2.Exists)
                    {
                        rec.IsExperimentCompleted = false;
                    }
                    else
                    {
                        rec.IsExperimentCompleted = true;
                        rec.ExperimentStarted = fileInfo2.CreationTime;
                        rec.ExperimentFinished = fileInfo2.LastWriteTime;
                        rec.CurvesCount = GetCurvesCount(path, seriesName);
                        if (!fileInfo3.Exists || !fileInfo4.Exists)
                        {
                            rec.IsExperimentAnalysed = false;
                        }
                        else
                        {
                            rec.IsExperimentAnalysed = true;
                            rec.ExperimentAnalysedFirst = fileInfo3.CreationTime;
                            rec.ExperimentAnalysedLast = fileInfo3.LastWriteTime;
                        }
                    }
                    rec.ExperimentType = binaryReader.ReadInt16();
                    input.Seek(6L, SeekOrigin.Begin);
                    rec.NumberOfIndentations = binaryReader.ReadInt16();
                    rec.IsModified = rec.IsExperimentCompleted && rec.CurvesCount != rec.NumberOfIndentations;
                    input.Seek(10L, SeekOrigin.Begin);
                    rec.ExperimentTerminationMethod = binaryReader.ReadInt16();
                    input.Seek(22L, SeekOrigin.Begin);
                    rec.ThermalDriftCorrectionTime = binaryReader.ReadInt16();
                    input.Seek(28L, SeekOrigin.Begin);
                    rec.NumberOfRows = binaryReader.ReadInt16();
                    rec.NumberOfColumns = binaryReader.ReadInt16();
                    input.Seek(50L, SeekOrigin.Begin);
                    rec.ThermalDriftCorrectionType = binaryReader.ReadInt16();
                    input.Seek(62L, SeekOrigin.Begin);
                    rec.RampType = binaryReader.ReadInt16();
                    input.Seek(100L, SeekOrigin.Begin);
                    rec.LoadMax = binaryReader.ReadSingle();
                    rec.LoadMin = binaryReader.ReadSingle();
                    rec.LimitStopLoad = binaryReader.ReadSingle();
                    rec.InitialLoad = binaryReader.ReadSingle();
                    rec.DepthMax = binaryReader.ReadSingle();
                    rec.DepthMin = binaryReader.ReadSingle();
                    input.Seek(124L, SeekOrigin.Begin);
                    rec.InitialZ = binaryReader.ReadSingle();
                    rec.InitialY = binaryReader.ReadSingle();
                    input.Seek(144L, SeekOrigin.Begin);
                    rec.InitialX = binaryReader.ReadSingle();
                    input.Seek(156L, SeekOrigin.Begin);
                    rec.LoadingRate = binaryReader.ReadSingle();
                    rec.UnloadingRate = binaryReader.ReadSingle();
                    rec.ProportionalConstant = binaryReader.ReadSingle();
                    input.Seek(260L, SeekOrigin.Begin);
                    rec.LoadingTime = binaryReader.ReadSingle();
                    rec.UnloadingTime = binaryReader.ReadSingle();
                    input.Seek(18L, SeekOrigin.Begin);
                    rec.DwellAtMaximumLoad = binaryReader.ReadInt16();
                }
            }
        }

        private static int GetCurvesCount(string path, string seriesName)
        {
            string path1 = $@"{path}\{seriesName}.idr";
            if (!File.Exists(path1))
                return 0;
            using (FileStream input = new FileStream(path1, FileMode.Open))
            {
                using (BinaryReader binaryReader = new BinaryReader(input))
                    return binaryReader.ReadInt32();
            }
        }

        private void ReadFile(
          string path,
          string seriesName,
          ref int si,
          ref int i,
          AdditionalInfo directoryInfo)
        {
            string fullFileName = $@"{path}\{seriesName}.ini";
            AdditionalInfo additionalInfo = ReadAdditionalInfo(fullFileName, directoryInfo);
            indentationSeriesArray[si].FolderAdditionalInfo = directoryInfo;
            indentationSeriesArray[si].FileAdditionalInfo = ReadAdditionalInfo(fullFileName);
            indentationSeriesArray[si].AdditionalInfo = additionalInfo;
            ReadIndentationSeries(path, seriesName, ref indentationSeriesArray[si]);
            indentationSeriesArray[si].FirstCurveIndex = i;
            if (indentationSeriesArray[si].IsExperimentAnalysed)
            {
                using (FileStream input1 = new FileStream($@"{path}\{seriesName}.ipf", FileMode.Open))
                {
                    using (FileStream input2 = new FileStream($@"{path}\{seriesName}.pft", FileMode.Open))
                    {
                        using (BinaryReader br1 = new BinaryReader(input1))
                        {
                            using (BinaryReader br2 = new BinaryReader(input2))
                            {
                                input1.Seek(132L, SeekOrigin.Begin);
                                double num1 = br1.ReadDouble();
                                double num2 = br1.ReadDouble();
                                for (int index = 0; index < indentationSeriesArray[si].CurvesCount; ++index)
                                {
                                    analysisResultsArray[i].IndenterE = num1;
                                    analysisResultsArray[i].IndenterNu = num2;
                                    analysisResultsArray[i].AdditionalInfo = additionalInfo;
                                    input1.Seek(416 + 244 * index, SeekOrigin.Begin);
                                    analysisResultsArray[i].SeriesNo = si;
                                    analysisResultsArray[i].SeriesName = seriesName;
                                    analysisResultsArray[i].CurveNo = index;
                                    analysisResultsArray[i].Result = DataReader.ReadAnalysisResults(br1);
                                    analysisResultsArray[i].Result.YoungsModulus = Materials.CalculateE(analysisResultsArray[i].Result.ReducedModulus, additionalInfo.Nu, analysisResultsArray[i].IndenterE, analysisResultsArray[i].IndenterNu);
                                    input2.Seek(24 * index, SeekOrigin.Begin);
                                    analysisResultsArray[i].PowerLawFitCoeffs = DataReader.ReadPowerLawFitCoeffs(br2);
                                    ++i;
                                }
                            }
                        }
                    }
                }
            }
            ++si;
        }

        private string GetDirectoryAdditionalInfoFullFileName(string path) => $@"{path}\_nt.ini";

        private AdditionalInfo ReadAdditionalInfo(string fullFileName) => ReadAdditionalInfo(fullFileName, AdditionalInfo.Default);
        private AdditionalInfo ReadAdditionalInfo(string fullFileName, AdditionalInfo defaultInfo)
        {
            AdditionalInfo additionalInfo = defaultInfo;
            string str1 = fullFileName;
            if (File.Exists(str1))
            {
                IIniFile iniFile = IniFileFactory.Create(str1);
                string str2 = iniFile.Read("Name", "Sample");
                if (str2.Length > 0)
                    additionalInfo.SampleName = str2;
                string s = iniFile.Read("nu", "Sample");
                if (s.Length > 0)
                    float.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out additionalInfo.Nu);
                string str3 = iniFile.Read("Accounting", "Operator");
                if (str3.Length > 0)
                    additionalInfo.OperatorName = str3;
                string str4 = iniFile.Read("Accounting", "Order");
                if (str4.Length > 0)
                    additionalInfo.OrderNumber = str4;
            }
            return additionalInfo;
        }

        private void IterateFilesAtPath(string path, bool recursive, SeriesDelegate handler)
        {
            DirectoryInfo directoryInfo1 = new DirectoryInfo(path);
            AdditionalInfo directoryInfo2 = ReadAdditionalInfo(GetDirectoryAdditionalInfoFullFileName(path));
            foreach (FileInfo file in directoryInfo1.GetFiles("*.ipf"))
            {
                string nameWoExtension = file.GetNameWoExtension();
                if (File.Exists($@"{path}\{nameWoExtension}.ind"))
                    handler(path, nameWoExtension, directoryInfo2);
            }
            if (!recursive)
                return;
            foreach (FileSystemInfo directory in directoryInfo1.GetDirectories())
                IterateFilesAtPath(directory.FullName, true, handler);
        }

        private delegate void SeriesDelegate(string path, string seriesName, AdditionalInfo directoryInfo);

        public class AnalysisReadingEventArgs : EventArgs
        {
            public int SeriesIndex { get; }

            public int CurveIndex { get; }

            public AnalysisReadingEventArgs(int seriesIndex, int curveIndex)
            {
                SeriesIndex = seriesIndex;
                CurveIndex = curveIndex;
            }
        }
    }
}
