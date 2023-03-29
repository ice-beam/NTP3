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
using System.Drawing;
using System.Globalization;

namespace NTP3AnalysisExportGUI
{
    public static class GuiUtils
    {
        public static string PointToPairString(Point a) => a.X.ToString(CultureInfo.InvariantCulture) + "," + a.Y.ToString(CultureInfo.InvariantCulture);

        public static string PointToPairString(Size a) => a.Width.ToString(CultureInfo.InvariantCulture) + "," + a.Height.ToString(CultureInfo.InvariantCulture);

        public static Point PairStringToPoint(string s, Point @default = default)
        {
            if (s == null)
                return @default;
            string[] strArray = s.Split(',');
            return strArray.Length < 2
                   || !int.TryParse(strArray[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out var x)
                   || !int.TryParse(strArray[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out var y)
                ? @default : new Point(x, y);
        }

        public static Size PairStringToPoint(string s, Size @default = default) => new Size(PairStringToPoint(s, new Point(@default)));
    }
}
