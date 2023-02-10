using Abp.AspNetCore.Mvc.Authorization;
using BabyMemory_V2.Controllers;
using BabyMemory_V2.Model.Childern;
using Microsoft.AspNetCore.Mvc;

namespace BabyMemory_V2.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ChildrenController : BabyMemory_V2ControllerBase
    {
        public IActionResult Index()
        {
            //TODO: Да всема децата на потребителя и да ги връща
            var model = new ChildrenViewModel[]
            {
                new ChildrenViewModel
                {
                    Id = null,
                    Name = "ПЕшо",
                    Age = 4,
                    LastName = "Петров",
                    BirthDate = default,
                    Picture = null,
                    Memories = null,
                    HealthProcedures = null
                }
            };
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
