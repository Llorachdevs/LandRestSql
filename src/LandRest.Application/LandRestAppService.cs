using System;
using System.Collections.Generic;
using System.Text;
using LandRest.Localization;
using Volo.Abp.Application.Services;

namespace LandRest
{
    /* Inherit your application services from this class.
     */
    public abstract class LandRestAppService : ApplicationService
    {
        protected LandRestAppService()
        {
            LocalizationResource = typeof(LandRestResource);
        }
    }
}
