using Plugin.Sample.Commerce.ExportCsv.Pipelines.Arguments;
using Sitecore.Commerce.Core;
using Sitecore.Framework.Pipelines;

namespace Plugin.Sample.Commerce.ExportCsv.Pipelines
{
    [PipelineDisplayName("Plugin.Sample.Commerce.ExportCsv.Pipelines.IStreamDataToCsvPipeline")]
    public interface IStreamDataToCsvPipeline : IPipeline<ExportDataArgument, bool, CommercePipelineExecutionContext>, IPipelineBlock<ExportDataArgument, bool, CommercePipelineExecutionContext>, IPipelineBlock, IPipeline
    {
    }
}
