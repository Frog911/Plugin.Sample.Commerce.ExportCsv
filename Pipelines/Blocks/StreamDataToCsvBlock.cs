using Plugin.Sample.Commerce.ExportCsv.Models;
using Plugin.Sample.Commerce.ExportCsv.Pipelines.Arguments;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Pricing;
using Sitecore.Framework.Conditions;
using Sitecore.Framework.Pipelines;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plugin.Sample.Commerce.ExportCsv.Pipelines.Blocks
{
    [PipelineDisplayName("Plugin.Sample.Commerce.ExportCsv.Pipelines.Blocks.StreamPriceBooksToArchiveBlock")]
    public class StreamDataToCsvBlock : PipelineBlock<ExportDataArgument, ExportDataArgument, CommercePipelineExecutionContext>
    {
        public StreamDataToCsvBlock(CommerceCommander commerceCommander)
          : base()
        {
        }

        public override Task<ExportDataArgument> Run(
          ExportDataArgument arg,
          CommercePipelineExecutionContext context)
        {
            var csv = arg.ExportCsv;

            var records = new List<FooModel>
            {
                new FooModel { Id = 1, Name = "one" },
                new FooModel { Id = 2, Name = "two" },
            };

            csv.WriteHeader<FooModel>();
            csv.NextRecord();
            foreach (var record in records)
            {
                csv.WriteRecord(record);
                csv.NextRecord();
            }

            return Task.FromResult(arg);
        }
    }
}
