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
using System.Globalization;

namespace NTP3
{
  public struct AnalysisResult
  {
    public double MaxDepth;
    public double ContactDepth;
    public double MaxLoad;
    public double Hardness;
    public double ReducedModulus;
    public double YoungsModulus;
    public double ERP;
    public double PlasticWork;
    public double ElasticWork;
    public double FittingMSE;
    public double ContactCompliance;

    public override string ToString() => string.Format(CultureInfo.InvariantCulture, "{0:F3}\t{1:F2}\t{2:F2}\t{3:F6}\t{4:F5}\t{5:F5}\t{6:F4}\t{7:F7}\t{8:F7}\t{9:F4}", MaxLoad, MaxDepth, ContactDepth, ContactCompliance, Hardness, ReducedModulus, ERP, PlasticWork, ElasticWork, FittingMSE);

    public static AnalysisResult operator +(AnalysisResult a, AnalysisResult b)
    {
      a.MaxDepth += b.MaxDepth;
      a.ContactDepth += b.ContactDepth;
      a.MaxLoad += b.MaxLoad;
      a.Hardness += b.Hardness;
      a.ReducedModulus += b.ReducedModulus;
      a.YoungsModulus += b.YoungsModulus;
      a.ERP += b.ERP;
      a.PlasticWork += b.PlasticWork;
      a.ElasticWork += b.ElasticWork;
      a.FittingMSE += b.FittingMSE;
      a.ContactCompliance += b.ContactCompliance;
      return a;
    }

    public static AnalysisResult operator -(AnalysisResult a, AnalysisResult b)
    {
      a.MaxDepth -= b.MaxDepth;
      a.ContactDepth -= b.ContactDepth;
      a.MaxLoad -= b.MaxLoad;
      a.Hardness -= b.Hardness;
      a.ReducedModulus -= b.ReducedModulus;
      a.YoungsModulus -= b.YoungsModulus;
      a.ERP -= b.ERP;
      a.PlasticWork -= b.PlasticWork;
      a.ElasticWork -= b.ElasticWork;
      a.FittingMSE -= b.FittingMSE;
      a.ContactCompliance -= b.ContactCompliance;
      return a;
    }

    public static AnalysisResult operator *(AnalysisResult a, AnalysisResult b)
    {
      a.MaxDepth *= b.MaxDepth;
      a.ContactDepth *= b.ContactDepth;
      a.MaxLoad *= b.MaxLoad;
      a.Hardness *= b.Hardness;
      a.ReducedModulus *= b.ReducedModulus;
      a.YoungsModulus *= b.YoungsModulus;
      a.ERP *= b.ERP;
      a.PlasticWork *= b.PlasticWork;
      a.ElasticWork *= b.ElasticWork;
      a.FittingMSE *= b.FittingMSE;
      a.ContactCompliance *= b.ContactCompliance;
      return a;
    }

    public static AnalysisResult operator /(AnalysisResult a, int x)
    {
      a.MaxDepth /= x;
      a.ContactDepth /= x;
      a.MaxLoad /= x;
      a.Hardness /= x;
      a.ReducedModulus /= x;
      a.YoungsModulus /= x;
      a.ERP /= x;
      a.PlasticWork /= x;
      a.ElasticWork /= x;
      a.FittingMSE /= x;
      a.ContactCompliance /= x;
      return a;
    }

    public AnalysisResult Sqrt()
    {
      AnalysisResult analysisResult;
      analysisResult.MaxDepth = Math.Sqrt(MaxDepth);
      analysisResult.ContactDepth = Math.Sqrt(ContactDepth);
      analysisResult.MaxLoad = Math.Sqrt(MaxLoad);
      analysisResult.Hardness = Math.Sqrt(Hardness);
      analysisResult.ReducedModulus = Math.Sqrt(ReducedModulus);
      analysisResult.YoungsModulus = Math.Sqrt(YoungsModulus);
      analysisResult.ERP = Math.Sqrt(ERP);
      analysisResult.PlasticWork = Math.Sqrt(PlasticWork);
      analysisResult.ElasticWork = Math.Sqrt(ElasticWork);
      analysisResult.FittingMSE = Math.Sqrt(FittingMSE);
      analysisResult.ContactCompliance = Math.Sqrt(ContactCompliance);
      return analysisResult;
    }
  }
}
