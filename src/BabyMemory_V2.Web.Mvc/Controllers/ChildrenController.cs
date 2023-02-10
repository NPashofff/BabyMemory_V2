using Abp.AspNetCore.Mvc.Authorization;
using BabyMemory_V2.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BabyMemory_V2.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ChildrenController : BabyMemory_V2ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
