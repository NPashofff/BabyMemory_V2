using Abp.AspNetCore.Mvc.Authorization;
using BabyMemory_V2.Constant;
using BabyMemory_V2.Controllers;
using BabyMemory_V2.Model.Childern;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Abp.Application.Services.Dto;
using BabyMemory_V2.Childrens;
using Abp.Runtime.Session;
using BabyMemory_V2.Model.Children;

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

        public async Task<IActionResult> Profile(long id)
        {
            var result = await _childrenAppService.GetAsync(new EntityDto<long>() { Id = id });

            return View(result);
        }

        public async Task<IActionResult> Edit(long childrenId)
        {
            var result = await _childrenAppService.GetAsync(new EntityDto<long>() { Id = childrenId });

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ChildrenDto model)
        {
            if (model.BirthDate > DateTime.Now) ModelState
                .AddModelError(nameof(model.BirthDate),
                    GlobalConstants.BirthDateError);

            if (!ModelState.IsValid) return View(model);

            await _childrenAppService.UpdateAsync(model);

            return Redirect("/Children/Profile/" + model.Id);
        }

        public async Task<IActionResult> Delete(long childrenId)
        {
            await _childrenAppService.DeleteAsync(new EntityDto<long>() { Id = childrenId });

            return Redirect("/Children/Index");
        }
    }
}
