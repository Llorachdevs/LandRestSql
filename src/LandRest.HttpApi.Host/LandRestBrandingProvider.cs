using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace LandRest
{
    [Dependency(ReplaceServices = true)]
    public class LandRestBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "LandRest";
    }
}
