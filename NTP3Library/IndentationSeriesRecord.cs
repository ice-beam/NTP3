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

namespace NTP3
{
    public struct IndentationSeriesRecord
    {
        public string FolderName;
        public string SeriesName;
        public string FullFileName;
        public int FirstCurveIndex;
        public short ExperimentType;
        public short NumberOfIndentations;
        public int CurvesCount;
        public bool IsModified;
        public int OriginalSeriesNo;
        public int LastModifiedSeriesNo;
        public DateTime ExperimentScheduled;
        public DateTime ExperimentStarted;
        public DateTime ExperimentFinished;
        public bool IsExperimentCompleted;
        public bool IsExperimentAnalysed;
        public DateTime ExperimentAnalysedFirst;
        public DateTime ExperimentAnalysedLast;
        public short ExperimentTerminationMethod;
        public float LoadMax;
        public float LoadMin;
        public float DepthMax;
        public float DepthMin;
        public short RampType;
        public float LimitStopLoad;
        public float InitialLoad;
        public float LoadingTime;
        public float UnloadingTime;
        public float LoadingRate;
        public float UnloadingRate;
        public float ProportionalConstant;
        public short DwellAtMaximumLoad;
        public short ThermalDriftCorrectionType;
        public short ThermalDriftCorrectionTime;
        public float InitialX;
        public float InitialY;
        public float InitialZ;
        public short NumberOfRows;
        public short NumberOfColumns;
        public AdditionalInfo AdditionalInfo;
        public AdditionalInfo FolderAdditionalInfo;
        public AdditionalInfo FileAdditionalInfo;
    }
}
