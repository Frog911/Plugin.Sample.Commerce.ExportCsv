using Plugin.Sample.Commerce.ExportCsv.Pipelines.Arguments;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Catalog;
using Sitecore.Framework.Pipelines;

namespace Plugin.Sample.Commerce.ExportCsv.Pipelines
{
    [PipelineDisplayName("Plugin.Sample.Commerce.ExportCsv.Pipelines.IExportDataPipeline")]
    public interface IExportDataPipeline : IPipeline<ExportDataArgument, FileCallbackResult, CommercePipelineExecutionContext>, IPipelineBlock<ExportDataArgument, FileCallbackResult, CommercePipelineExecutionContext>, IPipelineBlock, IPipeline
    {
    }
}
