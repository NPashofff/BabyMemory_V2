using System.Threading.Tasks;
using Abp.Configuration.Startup;
using BabyMemory_V2.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace BabyMemory_V2.Web.Views.Shared.Components.SideBarUserArea
{
    public class SideBarUserAreaViewComponent : BabyMemory_V2ViewComponent
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly IMultiTenancyConfig _multiTenancyConfig;

        public SideBarUserAreaViewComponent(
            ISessionAppService sessionAppService,
            IMultiTenancyConfig multiTenancyConfig)
        {
            _sessionAppService = sessionAppService;
            _multiTenancyConfig = multiTenancyConfig;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new SideBarUserAreaViewModel
            {
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations(),
                IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled,
            };

            return View(model);
        }
    }
}
