using Plugin.Sample.Commerce.ExportCsv.Pipelines;
using Plugin.Sample.Commerce.ExportCsv.Pipelines.Arguments;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Core.Commands;
using Sitecore.Commerce.Plugin.Catalog;
using Sitecore.Framework.Conditions;
using System;
using System.Threading.Tasks;

namespace Plugin.Sample.Commerce.ExportCsv.Commands
{
    public class ExportDataCommand : CommerceCommand
    {
        public ExportDataCommand(
          IExportDataPipeline exportDataPipeline,
          IServiceProvider serviceProvider)
          : base(serviceProvider)
        {
            Condition.Requires(exportDataPipeline, nameof(exportDataPipeline)).IsNotNull();
            this.ExportDataPipeline = exportDataPipeline;
        }

        protected IExportDataPipeline ExportDataPipeline { get; }

        public async Task<FileCallbackResult> Process(
          CommerceContext commerceContext,
          string fileName)
        {
            FileCallbackResult fileCallbackResult;
            using (CommandActivity.Start(commerceContext, this))
            {
                ExportDataArgument inventorySetsArgument = new ExportDataArgument(fileName);
                fileCallbackResult = await this.ExportDataPipeline.Run(inventorySetsArgument, commerceContext.PipelineContextOptions);
            }
            return fileCallbackResult;
        }
    }
}
