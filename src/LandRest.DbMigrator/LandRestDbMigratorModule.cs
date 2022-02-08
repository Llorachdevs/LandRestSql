using LandRest.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace LandRest.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(LandRestEntityFrameworkCoreModule),
        typeof(LandRestApplicationContractsModule)
        )]
    public class LandRestDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
