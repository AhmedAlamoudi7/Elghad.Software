using HiringWeb.Core.DTO;
using HiringWeb.Core.ViewModels;
using HiringWeb.Services.NotificationsOperations;
using HiringWeb.Services.OrgnizationOperations;
using HiringWeb.Services.UserOperations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrgnizationController : BaseController
    {
        private readonly IOrgnizationServices _OrgServices;

        public OrgnizationController(IOrgnizationServices OrgServices,
            IUserServices UserOperation, INotificationServices INotificationServices) : base(UserOperation, INotificationServices)
        {
            _OrgServices = OrgServices;
        }
        
        public async Task<IActionResult> Index(int Id, string SearchWord, int SelectSize)
        {
            var AllOrg = await _OrgServices.Index(Id, SearchWord, SelectSize);
            ViewBag.SearchWord = SearchWord;
            ViewBag.SelectSize = SelectSize;
            return View(AllOrg);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var users = await _OrgServices.AddGet();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ErrorOrgnizeAdd SetOrg, IFormFile ProfileImage)
        {
            //Save Image(File) In DB
            if (ProfileImage != null)
            {
                using (var fileStore = new MemoryStream())
                {
                    await ProfileImage.CopyToAsync(fileStore);
                    SetOrg.OrgnizationAddDto.ProfileImgUser = fileStore.ToArray();
                }
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var ResultAdd = await _OrgServices.Add(SetOrg.OrgnizationAddDto, userId);
            if(ResultAdd.IsFalid == false)
            {
                //ViewBag.ResError = ResultAdd.ResultError;
                TempData["ResError"] = $"e: {ResultAdd.ResultError}";

                return View(SetOrg);
            }
            TempData["ResError"] = $"s: لقد تم إضافة الشركة بنجاح.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var GetModel = await _OrgServices.EditGet(Id);
            if (!GetModel.IsFalid)
            {
                return NotFound();
            }
            return View(GetModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ErrorOrgnizeEdit EditOrg, IFormFile ProfileImage)
        {
            //Save Image(File) In DB
            if (ProfileImage != null)
            {
                using (var fileStore = new MemoryStream())
                {
                    await ProfileImage.CopyToAsync(fileStore);
                    EditOrg.OrgnizationEditDto.ProfileImgUser = fileStore.ToArray();
                }
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

            var SetModel = await _OrgServices.EditPost(EditOrg.OrgnizationEditDto, userId);
            if (!SetModel.IsFalid)
            {
                //ViewBag.ResError = SetModel.ResultError;
                TempData["ResError"] = $"e: {SetModel.ResultError}";
                return View(SetModel);
            }
            TempData["ResError"] = $"s: لقد تم تعديل بيانات الشركة بنجاح.";

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var GetOrg = await _OrgServices.ReturnOrgnization(Id);
            var OrgDel = await _OrgServices.Delete(Id);
            if(OrgDel == false)
            {
                return NotFound();
            }
            //TempData["SuccessDel"] = "لقد تم حذف شركة/ "+ GetOrg.Name + " ومديرها المستخدم / " + GetOrg.User.FullName;
            TempData["ResError"] = $"s: لقد تم حذف شركة / {GetOrg.Name} ومديرها المستخدم / {GetOrg.User.FullName} بنجاح.";
            return RedirectToAction(nameof(Index));
        }
    }
}
