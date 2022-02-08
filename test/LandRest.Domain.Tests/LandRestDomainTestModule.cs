using LandRest.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LandRest
{
    [DependsOn(
        typeof(LandRestEntityFrameworkCoreTestModule)
        )]
    public class LandRestDomainTestModule : AbpModule
    {

    }
}