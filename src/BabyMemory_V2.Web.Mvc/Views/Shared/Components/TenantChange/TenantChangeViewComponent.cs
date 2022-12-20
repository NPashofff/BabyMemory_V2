using System.Threading.Tasks;
using Abp.ObjectMapping;
using BabyMemory_V2.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace BabyMemory_V2.Web.Views.Shared.Components.TenantChange
{
    public class TenantChangeViewComponent : BabyMemory_V2ViewComponent
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly IObjectMapper _objectMapper;

        public TenantChangeViewComponent(ISessionAppService sessionAppService, IObjectMapper objectMapper)
        {
            _sessionAppService = sessionAppService;
            _objectMapper = objectMapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loginInfo = await _sessionAppService.GetCurrentLoginInformations();
            var model = _objectMapper.Map<TenantChangeViewModel>(loginInfo);
            return View(model);
        }
    }
}
