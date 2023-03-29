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
using System.Collections.Generic;
using System.Linq;

namespace NTP3
{
    public class AnalysisExportColumnSpecification
    {
        public static readonly AnalysisExportColumnSpecification[] Specifications =
        {
      new AnalysisExportColumnSpecification("OperatorName", "Operator Name", "", false, AnalysisResultsRecordField.AdditionalInfo, AnalysisResultsRecordSubfield.OperatorName),
      new AnalysisExportColumnSpecification("OrderNumber", "Order Number", "", false, AnalysisResultsRecordField.AdditionalInfo, AnalysisResultsRecordSubfield.OrderNumber),
      new AnalysisExportColumnSpecification("SampleName", "Sample Name", "", false, AnalysisResultsRecordField.AdditionalInfo, AnalysisResultsRecordSubfield.SampleName),
      new AnalysisExportColumnSpecification("SeriesName", "Series Name", "", false, AnalysisResultsRecordField.SeriesName, AnalysisResultsRecordSubfield.None),
      new AnalysisExportColumnSpecification("Pmax", "Max. Load", "mN", false, AnalysisResultsRecordField.AnalysisResult, AnalysisResultsRecordSubfield.MaxLoad),
      new AnalysisExportColumnSpecification("hmax", "Max. Depth", "nm", false, AnalysisResultsRecordField.AnalysisResult, AnalysisResultsRecordSubfield.MaxDepth),
      new AnalysisExportColumnSpecification("hc", "Contact Depth", "nm", false, AnalysisResultsRecordField.AnalysisResult, AnalysisResultsRecordSubfield.ContactDepth),
      new AnalysisExportColumnSpecification("C", "Contact Compliance", "nm/mN", false, AnalysisResultsRecordField.AnalysisResult, AnalysisResultsRecordSubfield.ContactCompliance),
      new AnalysisExportColumnSpecification("H", "Hardness", "GPa", false, AnalysisResultsRecordField.AnalysisResult, AnalysisResultsRecordSubfield.Hardness),
      new AnalysisExportColumnSpecification("Er", "Reduced Modulus", "GPa", false, AnalysisResultsRecordField.AnalysisResult, AnalysisResultsRecordSubfield.ReducedModulus),
      new AnalysisExportColumnSpecification("E", "Young's Modulus", "GPa", false, AnalysisResultsRecordField.AnalysisResult, AnalysisResultsRecordSubfield.YoungsModulus),
      new AnalysisExportColumnSpecification("ERP", "ERP", "", false, AnalysisResultsRecordField.AnalysisResult, AnalysisResultsRecordSubfield.ERP),
      new AnalysisExportColumnSpecification("Wp", "Plastic Work", "nJ", false, AnalysisResultsRecordField.AnalysisResult, AnalysisResultsRecordSubfield.PlasticWork),
      new AnalysisExportColumnSpecification("We", "Elastic Work", "nJ", false, AnalysisResultsRecordField.AnalysisResult, AnalysisResultsRecordSubfield.ElasticWork),
      new AnalysisExportColumnSpecification("FitMSE", "Fit MSE", "", false, AnalysisResultsRecordField.AnalysisResult, AnalysisResultsRecordSubfield.FittingMSE),
      new AnalysisExportColumnSpecification("SD:Pmax", "Max. Load StDev", "mN", true, AnalysisResultsRecordField.AnalysisResultStDev, AnalysisResultsRecordSubfield.MaxLoad),
      new AnalysisExportColumnSpecification("SD:hmax", "Max. Depth StDev", "nm", true, AnalysisResultsRecordField.AnalysisResultStDev, AnalysisResultsRecordSubfield.MaxDepth),
      new AnalysisExportColumnSpecification("SD:hc", "Contact Depth StDev", "nm", true, AnalysisResultsRecordField.AnalysisResultStDev, AnalysisResultsRecordSubfield.ContactDepth),
      new AnalysisExportColumnSpecification("SD:C", "Contact Compliance StDev", "nm/mN", true, AnalysisResultsRecordField.AnalysisResultStDev, AnalysisResultsRecordSubfield.ContactCompliance),
      new AnalysisExportColumnSpecification("SD:H", "Hardness StDev", "GPa", true, AnalysisResultsRecordField.AnalysisResultStDev, AnalysisResultsRecordSubfield.Hardness),
      new AnalysisExportColumnSpecification("SD:Er", "Reduced Modulus StDev", "GPa", true, AnalysisResultsRecordField.AnalysisResultStDev, AnalysisResultsRecordSubfield.ReducedModulus),
      new AnalysisExportColumnSpecification("SD:E", "Young's Modulus StDev", "GPa", true, AnalysisResultsRecordField.AnalysisResultStDev, AnalysisResultsRecordSubfield.YoungsModulus),
      new AnalysisExportColumnSpecification("SD:ERP", "ERP StDev", "", true, AnalysisResultsRecordField.AnalysisResultStDev, AnalysisResultsRecordSubfield.ERP),
      new AnalysisExportColumnSpecification("SD:Wp", "Plastic Work StDev", "nJ", true, AnalysisResultsRecordField.AnalysisResultStDev, AnalysisResultsRecordSubfield.PlasticWork),
      new AnalysisExportColumnSpecification("SD:We", "Elastic Work StDev", "nJ", true, AnalysisResultsRecordField.AnalysisResultStDev, AnalysisResultsRecordSubfield.ElasticWork),
      new AnalysisExportColumnSpecification("SD:FitMSE", "Fit MSE StDev", "", true, AnalysisResultsRecordField.AnalysisResultStDev, AnalysisResultsRecordSubfield.FittingMSE),
      new AnalysisExportColumnSpecification("PLF:a", "PLF:a", "", false, AnalysisResultsRecordField.PowerLawFitCoeffs, AnalysisResultsRecordSubfield.a),
      new AnalysisExportColumnSpecification("PLF:hp", "PLF:hp", "nm", false, AnalysisResultsRecordField.PowerLawFitCoeffs, AnalysisResultsRecordSubfield.hp),
      new AnalysisExportColumnSpecification("PLF:m", "PLF:m", "", false, AnalysisResultsRecordField.PowerLawFitCoeffs, AnalysisResultsRecordSubfield.m),
      new AnalysisExportColumnSpecification("ExpScheduled", "Experiment Schedule Time", "", false, AnalysisResultsRecordField.IndentationSeries, AnalysisResultsRecordSubfield.ExperimentScheduled),
      new AnalysisExportColumnSpecification("ExpStarted", "Experiment Start Time", "", false, AnalysisResultsRecordField.IndentationSeries, AnalysisResultsRecordSubfield.ExperimentStarted),
      new AnalysisExportColumnSpecification("ExpFinished", "Experiment Finish Time", "", false, AnalysisResultsRecordField.IndentationSeries, AnalysisResultsRecordSubfield.ExperimentFinished),
      new AnalysisExportColumnSpecification("ExpAnalysedFirst", "Experiment Analyse First Time", "", false, AnalysisResultsRecordField.IndentationSeries, AnalysisResultsRecordSubfield.ExperimentAnalysedFirst),
      new AnalysisExportColumnSpecification("ExpAnalysedLast", "Experiment Analyse Last Time", "", false, AnalysisResultsRecordField.IndentationSeries, AnalysisResultsRecordSubfield.ExperimentAnalysedLast)
        };
        public static readonly AnalysisExportColumnSpecification[] DefaultSet =
        {
      Get("SeriesName"),
      Get("Pmax"),
      Get("hmax"),
      Get("hc"),
      Get("C"),
      Get("H"),
      Get("Er"),
      Get("FitMSE"),
      Get("PLF:a"),
      Get("PLF:hp"),
      Get("PLF:m")
        };
        public static readonly AnalysisExportColumnSpecification[] DefaultAvgSet =
        {
      Get("SeriesName"),
      Get("Pmax"),
      Get("hmax"),
      Get("hc"),
      Get("C"),
      Get("H"),
      Get("Er"),
      Get("FitMSE"),
      Get("SD:hmax"),
      Get("SD:hc"),
      Get("SD:C"),
      Get("SD:H"),
      Get("SD:Er")
        };

        public string Name { get; }

        public string DisplayName { get; }

        public string Unit { get; }

        public bool AverageOnly { get; }

        public AnalysisExportColumn Column { get; }

        private AnalysisExportColumnSpecification(
          string name,
          string displayName,
          string unit,
          bool averageOnly,
          AnalysisResultsRecordField field,
          AnalysisResultsRecordSubfield subfield)
        {
            Name = name;
            DisplayName = displayName;
            Unit = unit;
            AverageOnly = averageOnly;
            Column = new AnalysisExportColumn(field, subfield);
        }

        public override string ToString() => DisplayName;

        public static AnalysisExportColumnSpecification Get(string name) => Specifications.First(x => x.Name == name);

        public static IEnumerable<AnalysisExportColumnSpecification> Get(
          string[] names)
        {
            return Specifications.Where(x => names.Contains(x.Name));
        }

        public static IEnumerable<AnalysisExportColumnSpecification> GetOrdered(
          string[] names)
        {
            return names.Select(name => Specifications.FirstOrDefault(spec => spec.Name == name)).Where(spec => spec != null);
        }
    }
}
