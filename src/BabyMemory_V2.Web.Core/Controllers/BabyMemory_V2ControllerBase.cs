using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace BabyMemory_V2.Controllers
{
    public abstract class BabyMemory_V2ControllerBase: AbpController
    {
        protected BabyMemory_V2ControllerBase()
        {
            LocalizationSourceName = BabyMemory_V2Consts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
