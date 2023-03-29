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
namespace NTP3
{
    public struct AdditionalInfo
    {
        public string SampleName;
        public string OperatorName;
        public string OrderNumber;
        public float Nu;

        public const string StringEmptyCode = "";
        public const string StringVarietyCode = "#";
        /// <remarks>
        /// Use only for setting, not for comparison
        /// </remarks>
        public const float FloatEmptyCode = float.PositiveInfinity;
        /// <remarks>
        /// Use only for setting, not for comparison
        /// </remarks>
        public const float FloatVarietyCode = float.NaN;

        public static readonly AdditionalInfo Default = new AdditionalInfo(null, null, null, FloatEmptyCode);

        public AdditionalInfo(string sampleName, string operatorName, string orderNumber, float nu)
        {
            SampleName = sampleName;
            OperatorName = operatorName;
            OrderNumber = orderNumber;
            Nu = nu;
        }

        public bool Empty => IsEmpty(SampleName) && IsEmpty(OperatorName) && IsEmpty(OrderNumber) && IsEmpty(Nu);

        public bool Variety => IsVariety(SampleName) && IsVariety(OperatorName) && IsVariety(OrderNumber) && IsVariety(Nu);

        public static bool IsVariety(string value) => value == StringVarietyCode;

        /// <see cref="FloatVarietyCode"/>
        public static bool IsVariety(float value) => float.IsNaN(value);

        public static bool IsEmpty(string value) => IsStringEmptyOrNull(value);

        /// <see cref="FloatEmptyCode"/>
        public static bool IsEmpty(float value) => float.IsPositiveInfinity(value);

        private static bool IsStringEmptyOrNull(string s) => s == null || s == StringEmptyCode;
    }
}
