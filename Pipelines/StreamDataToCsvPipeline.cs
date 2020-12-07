using Microsoft.Extensions.Logging;
using Plugin.Sample.Commerce.ExportCsv.Pipelines.Arguments;
using Sitecore.Commerce.Core;
using Sitecore.Framework.Pipelines;

namespace Plugin.Sample.Commerce.ExportCsv.Pipelines
{
    public class StreamDataToCsvPipeline : CommercePipeline<ExportDataArgument, bool>, IStreamDataToCsvPipeline, IPipeline<ExportDataArgument, bool, CommercePipelineExecutionContext>, IPipelineBlock<ExportDataArgument, bool, CommercePipelineExecutionContext>, IPipelineBlock, IPipeline
    {
        public StreamDataToCsvPipeline(
          IPipelineConfiguration<IStreamDataToCsvPipeline> configuration,
          ILoggerFactory loggerFactory)
          : base(configuration, loggerFactory)
        {
        }
    }
}
