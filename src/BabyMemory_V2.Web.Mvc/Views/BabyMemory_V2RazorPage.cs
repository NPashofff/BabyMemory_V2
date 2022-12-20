using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace BabyMemory_V2.Web.Views
{
    public abstract class BabyMemory_V2RazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected BabyMemory_V2RazorPage()
        {
            LocalizationSourceName = BabyMemory_V2Consts.LocalizationSourceName;
        }
    }
}
