namespace Sitecore.Commerce.Plugin.Sample
{
    using System.Reflection;
    using global::Plugin.Sample.Commerce.ExportCsv.Pipelines;
    using global::Plugin.Sample.Commerce.ExportCsv.Pipelines.Blocks;
    using Microsoft.Extensions.DependencyInjection;
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Plugin.Catalog;
    using Sitecore.Framework.Configuration;
    using Sitecore.Framework.Pipelines.Definitions.Extensions;

    public class ConfigureSitecore : IConfigureSitecore
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.RegisterAllPipelineBlocks(assembly);

            services.Sitecore().Pipelines(config => config

               .AddPipeline<IExportDataPipeline, ExportDataPipeline>(
                    configure =>
                    {
                        configure.Add<ExportDataBlock>();
                    })
               .AddPipeline<IStreamDataToCsvPipeline, StreamDataToCsvPipeline>(
                    configure =>
                    {
                        configure.Add<StreamDataToCsvBlock>();
                    })

               .ConfigurePipeline<IConfigureServiceApiPipeline>(configure => configure.Add<ConfigureServiceApiBlock>()));

            services.RegisterAllCommands(assembly);
        }
    }
}