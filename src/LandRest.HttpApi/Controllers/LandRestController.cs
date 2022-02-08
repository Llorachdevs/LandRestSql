using LandRest.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LandRest.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class LandRestController : AbpController
    {
        protected LandRestController()
        {
            LocalizationResource = typeof(LandRestResource);
        }
    }
}