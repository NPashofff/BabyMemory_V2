using Abp.AspNetCore.Mvc.ViewComponents;

namespace BabyMemory_V2.Web.Views
{
    public abstract class BabyMemory_V2ViewComponent : AbpViewComponent
    {
        protected BabyMemory_V2ViewComponent()
        {
            LocalizationSourceName = BabyMemory_V2Consts.LocalizationSourceName;
        }
    }
}
