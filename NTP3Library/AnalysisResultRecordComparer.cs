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
using System.Collections.Generic;

namespace NTP3
{
    public class AnalysisResultRecordComparer : IComparer<AnalysisResultRecord>
    {
        public int Compare(AnalysisResultRecord x, AnalysisResultRecord y)
        {
            if (x.AdditionalInfo.SampleName != null && y.AdditionalInfo.SampleName != null)
            {
                int num = string.Compare(x.AdditionalInfo.SampleName, y.AdditionalInfo.SampleName, StringComparison.InvariantCulture);
                if (num != 0)
                    return num;
            }
            int num1 = x.Result.MaxLoad.CompareTo(y.Result.MaxLoad);
            if (num1 != 0)
                return num1;
            if (x.SeriesName != null && y.SeriesName != null)
                num1 = string.Compare(x.SeriesName, y.SeriesName, StringComparison.InvariantCulture);
            return num1 != 0 ? num1 : x.CurveNo.CompareTo(y.CurveNo);
        }
    }
}
