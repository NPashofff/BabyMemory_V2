using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using BabyMemory_V2.Controllers;

namespace BabyMemory_V2.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : BabyMemory_V2ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
