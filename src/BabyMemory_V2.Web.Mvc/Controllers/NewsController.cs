using BabyMemory_V2.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BabyMemory_V2.Web.Controllers
{
    public class NewsController : BabyMemory_V2ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
