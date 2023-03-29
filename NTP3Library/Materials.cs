﻿/*
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
    public static class Materials
    {
        public static double CalculateE(double Er, double nus, double Ei, double nui) => (1.0 - nus * nus) / (1.0 / Er - (1.0 - nui * nui) / Ei);

        public static double CalculateEr(double Es, double nus, double Ei, double nui) => 1.0 / ((1.0 - nus * nus) / Es + (1.0 - nui * nui) / Ei);
    }
}