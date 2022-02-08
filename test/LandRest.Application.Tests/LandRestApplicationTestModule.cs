using Volo.Abp.Modularity;

namespace LandRest
{
    [DependsOn(
        typeof(LandRestApplicationModule),
        typeof(LandRestDomainTestModule)
        )]
    public class LandRestApplicationTestModule : AbpModule
    {

    }
}