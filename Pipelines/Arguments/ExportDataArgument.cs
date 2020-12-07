using CsvHelper;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Catalog;
using Sitecore.Framework.Conditions;
using System.Collections.Generic;
using System.IO.Compression;

namespace Plugin.Sample.Commerce.ExportCsv.Pipelines.Arguments
{
    public class ExportDataArgument : PipelineArgument
    {
        public CsvWriter ExportCsv { get; set; }

        public string FileName { get; set; }

        public ExportDataArgument(string fileName)
        {
            FileName = fileName;
        }
    }
}
