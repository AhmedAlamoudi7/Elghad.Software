using HiringWeb.Core.DTO;
using HiringWeb.Core.ViewModels;
using HiringWeb.Services.NotificationsOperations;
using HiringWeb.Services.RoleOperations;
using HiringWeb.Services.UserOperations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : BaseController
    {
        private readonly IRoleServices _RoleServices;

        public RoleController(IRoleServices RoleServices,
            IUserServices UserOperation, INotificationServices INotificationServices) : base(UserOperation, INotificationServices)
        {
            _RoleServices = RoleServices;
        }

        public async Task<IActionResult> Index()
        {
            var Roles = await _RoleServices.Index(); 
            return View(Roles);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoleAddDto role)
        {
            await _RoleServices.Add(role);
            TempData["ResError"] = "s: لقد تم إضافة الصلاحية بنجاح.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            return View(await _RoleServices.EditGet(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleEditDto role)
        {
            await _RoleServices.EditPost(role);
            TempData["ResError"] = "s: لقد تم تعديل الصلاحية بنجاح.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string Id)
        {
           await _RoleServices.Delete(Id);
            TempData["ResError"] = "s: لقد تم حذف الصلاحية بنجاح.";
            return RedirectToAction(nameof(Index));
        }

    }
}
