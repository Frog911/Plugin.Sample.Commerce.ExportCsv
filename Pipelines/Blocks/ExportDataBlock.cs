using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Plugin.Sample.Commerce.ExportCsv.Pipelines.Arguments;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Catalog;
using Sitecore.Framework.Conditions;
using Sitecore.Framework.Pipelines;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace Plugin.Sample.Commerce.ExportCsv.Pipelines.Blocks
{
    [PipelineDisplayName("Inventory.block.ExportPriceBooks")]
    public class ExportDataBlock : PipelineBlock<ExportDataArgument, FileCallbackResult, CommercePipelineExecutionContext>
    {
        public ExportDataBlock(
          IStreamDataToCsvPipeline streamDataToCsvPipeline)
          : base(null)
        {
            Condition.Requires(streamDataToCsvPipeline, nameof(streamDataToCsvPipeline)).IsNotNull();
            this.StreamDataToCsvPipeline = streamDataToCsvPipeline;
        }

        protected IStreamDataToCsvPipeline StreamDataToCsvPipeline { get; }

        public override Task<FileCallbackResult> Run(
          ExportDataArgument arg,
          CommercePipelineExecutionContext context)
        {
            Condition.Requires(arg, nameof(arg)).IsNotNull();
            FileCallbackResult result = new FileCallbackResult("application/octet-stream", async (outputStream, callbackContext) =>
            {
                using (var writer = new StreamWriter(outputStream))
                {
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        arg.ExportCsv = csv;
                        await this.StreamDataToCsvPipeline.Run(arg, context).ConfigureAwait(false);
                        
                    }
                }
            });

            result.FileDownloadName = arg.FileName;
            return Task.FromResult(result);
        }
    }
}
