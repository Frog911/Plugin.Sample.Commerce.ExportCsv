using Microsoft.Extensions.Logging;
using Plugin.Sample.Commerce.ExportCsv.Pipelines.Arguments;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Catalog;
using Sitecore.Framework.Pipelines;

namespace Plugin.Sample.Commerce.ExportCsv.Pipelines
{
    public class ExportDataPipeline : CommercePipeline<ExportDataArgument, FileCallbackResult>, IExportDataPipeline, IPipeline<ExportDataArgument, FileCallbackResult, CommercePipelineExecutionContext>, IPipelineBlock<ExportDataArgument, FileCallbackResult, CommercePipelineExecutionContext>, IPipelineBlock, IPipeline
    {
        public ExportDataPipeline(
          IPipelineConfiguration<IExportDataPipeline> configuration,
          ILoggerFactory loggerFactory)
          : base(configuration, loggerFactory)
        {
        }
    }
}
