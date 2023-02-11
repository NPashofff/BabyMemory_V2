using Abp.AspNetCore.Mvc.Authorization;
using BabyMemory_V2.Constant;
using BabyMemory_V2.Controllers;
using BabyMemory_V2.Model.Childern;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using BabyMemory_V2.Childrens;
using Abp.Runtime.Session;

namespace BabyMemory_V2.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ChildrenController : BabyMemory_V2ControllerBase
    {
        private readonly ChildrenAppService _childrenAppService;

        public ChildrenController(ChildrenAppService childrenAppService)
        {
            _childrenAppService = childrenAppService;
        }

        public async Task<IActionResult> Index()
        {
            //TODO: Да всема децата на потребителя и да ги връща
            ChildrenDto[] model = await _childrenAppService.GetAllCildenByUser(AbpSession.UserId);


            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateChildrenDto model)
        {
            if (model.BirthDate > DateTime.Now) ModelState
                .AddModelError(nameof(model.BirthDate),
                    GlobalConstants.BirthDateError);

            if (!ModelState.IsValid) return View(model);
            var x = AbpSession.GetUserId();
            model.UserId = AbpSession.GetUserId();

            await _childrenAppService.CreateAsync(model);

            return Redirect("/Children");
        }
    }
}
