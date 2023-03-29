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
    public static class AnalysisResultsFormatter
    {
        public static string Format(
          AnalysisResultRecord rec,
          IndentationSeriesRecord series,
          AnalysisExportColumn column)
        {
            return Format(rec, series, column.Field, column.Subfield);
        }

        public static string Format(
          AnalysisResultRecord rec,
          IndentationSeriesRecord series,
          AnalysisResultsRecordField field,
          AnalysisResultsRecordSubfield subfield)
        {
            string str;
            switch (field)
            {
                case AnalysisResultsRecordField.AdditionalInfo:
                    str = FormatAdditionalInfo(rec.AdditionalInfo, subfield);
                    break;
                case AnalysisResultsRecordField.SeriesName:
                    str = rec.SeriesName ?? "";
                    break;
                case AnalysisResultsRecordField.CurveNo:
                    str = string.Format(CultureInfo.InvariantCulture, "{0}", rec.CurveNo);
                    break;
                case AnalysisResultsRecordField.AnalysisResult:
                    str = FormatAnalysisResult(rec.Result, subfield);
                    break;
                case AnalysisResultsRecordField.AnalysisResultStDev:
                    str = FormatAnalysisResult(rec.Result, subfield);
                    break;
                case AnalysisResultsRecordField.PowerLawFitCoeffs:
                    str = FormatPowerLawFitCoeffs(rec.PowerLawFitCoeffs, subfield);
                    break;
                case AnalysisResultsRecordField.IndentationSeries:
                    str = FormatIndentationSeries(series, subfield);
                    break;
                default:
                    throw new FieldNotHandledException();
            }
            return str ?? throw new FieldHandledToNullException(field, subfield);
        }

        public static string FormatAdditionalInfo(
          AdditionalInfo info,
          AnalysisResultsRecordSubfield field)
        {
            string str;
            switch (field)
            {
                case AnalysisResultsRecordSubfield.SampleName:
                    str = info.SampleName;
                    break;
                case AnalysisResultsRecordSubfield.OperatorName:
                    str = info.OperatorName;
                    break;
                case AnalysisResultsRecordSubfield.OrderNumber:
                    str = info.OrderNumber;
                    break;
                case AnalysisResultsRecordSubfield.PoissonsRatio:
                    str = AdditionalInfo.IsEmpty(info.Nu) ? "" : info.Nu.ToString("{0:F3}", CultureInfo.InvariantCulture);
                    break;
                default:
                    throw new FieldNotHandledException();
            }
            return str ?? "";
        }

        public static string FormatAnalysisResult(
          AnalysisResult res,
          AnalysisResultsRecordSubfield field)
        {
            switch (field)
            {
                case AnalysisResultsRecordSubfield.MaxDepth:
                    return string.Format(CultureInfo.InvariantCulture, "{0:F2}", res.MaxDepth);
                case AnalysisResultsRecordSubfield.ContactDepth:
                    return string.Format(CultureInfo.InvariantCulture, "{0:F2}", res.ContactDepth);
                case AnalysisResultsRecordSubfield.MaxLoad:
                    return string.Format(CultureInfo.InvariantCulture, "{0:F3}", res.MaxLoad);
                case AnalysisResultsRecordSubfield.Hardness:
                    return string.Format(CultureInfo.InvariantCulture, "{0:F5}", res.Hardness);
                case AnalysisResultsRecordSubfield.ReducedModulus:
                    return string.Format(CultureInfo.InvariantCulture, "{0:F5}", res.ReducedModulus);
                case AnalysisResultsRecordSubfield.YoungsModulus:
                    return string.Format(CultureInfo.InvariantCulture, "{0:F5}", res.YoungsModulus);
                case AnalysisResultsRecordSubfield.ERP:
                    return string.Format(CultureInfo.InvariantCulture, "{0:F4}", res.ERP);
                case AnalysisResultsRecordSubfield.PlasticWork:
                    return string.Format(CultureInfo.InvariantCulture, "{0:F7}", res.PlasticWork);
                case AnalysisResultsRecordSubfield.ElasticWork:
                    return string.Format(CultureInfo.InvariantCulture, "{0:F7}", res.ElasticWork);
                case AnalysisResultsRecordSubfield.FittingMSE:
                    return string.Format(CultureInfo.InvariantCulture, "{0:F4}", res.FittingMSE);
                case AnalysisResultsRecordSubfield.ContactCompliance:
                    return string.Format(CultureInfo.InvariantCulture, "{0:F6}", res.ContactCompliance);
                default:
                    throw new FieldNotHandledException();
            }
        }

        public static string FormatPowerLawFitCoeffs(
          PowerLawFitCoeffs plfc,
          AnalysisResultsRecordSubfield field)
        {
            switch (field)
            {
                case AnalysisResultsRecordSubfield.a:
                    return string.Format(CultureInfo.InvariantCulture, "{0:F16}", plfc.a);
                case AnalysisResultsRecordSubfield.hp:
                    return string.Format(CultureInfo.InvariantCulture, "{0:F16}", plfc.hp);
                case AnalysisResultsRecordSubfield.m:
                    return string.Format(CultureInfo.InvariantCulture, "{0:F16}", plfc.m);
                default:
                    throw new FieldNotHandledException();
            }
        }

        public static string FormatIndentationSeries(IndentationSeriesRecord series, AnalysisResultsRecordSubfield field)
        {
            switch (field)
            {
                case AnalysisResultsRecordSubfield.ExperimentScheduled:
                    return FormatDateTime(series.ExperimentScheduled);
                case AnalysisResultsRecordSubfield.ExperimentStarted:
                    return FormatDateTime(series.ExperimentStarted);
                case AnalysisResultsRecordSubfield.ExperimentFinished:
                    return FormatDateTime(series.ExperimentFinished);
                case AnalysisResultsRecordSubfield.ExperimentAnalysedFirst:
                    return FormatDateTime(series.ExperimentAnalysedFirst);
                case AnalysisResultsRecordSubfield.ExperimentAnalysedLast:
                    return FormatDateTime(series.ExperimentAnalysedLast);
                default:
                    throw new FieldNotHandledException();
            }
        }

        private static string FormatDateTime(DateTime dt) => $"{dt:yyyy-MM-dd} {dt:HH:mm:ss}";

        public class FieldNotHandledException : Exception
        {
            public FieldNotHandledException()
              : base("Field type not handled")
            {
            }
        }

        public class FieldHandledToNullException : Exception
        {
            public FieldHandledToNullException(AnalysisResultsRecordField field, AnalysisResultsRecordSubfield subfield)
              : base("Null obtained when handling field " + field + "." + subfield)
            {
            }
        }
    }
}
