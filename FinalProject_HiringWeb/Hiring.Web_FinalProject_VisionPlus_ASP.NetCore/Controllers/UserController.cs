using AutoMapper;
using HiringWeb.Core.DTO;
using HiringWeb.Core.ViewModels;
using HiringWeb.DataBase.Models;
using HiringWeb.Services.NotificationsOperations;
using HiringWeb.Services.OrgnizationOperations;
using HiringWeb.Services.UserOperations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class UserController : BaseController
    {
        private readonly IUserServices _IUserServices;
        private readonly IOrgnizationServices _OrgServices;
        private readonly IMapper _Mapper;
        private readonly SignInManager<UserApplication> _SignInManager;



        public UserController(IUserServices IUserServices,
                              IOrgnizationServices OrgServices,
                              SignInManager<UserApplication> SignInManager,
                              IMapper Mapper, IUserServices UserOperation,
                              INotificationServices INotificationServices) : base(UserOperation, INotificationServices)
        {
            _IUserServices = IUserServices;
            _OrgServices = OrgServices;
            _Mapper = Mapper;
            _SignInManager = SignInManager;
        }
        public async Task<IActionResult> Index(int Id, string SearchWord, int SelectSize)
        {
            var AllUser = await _IUserServices.Index(Id, SearchWord, SelectSize);
            ViewBag.SearchWord = SearchWord;
            ViewBag.SelectSize = SelectSize;
            return View(AllUser);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var users = await _IUserServices.AddGet();
            return View(users);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ErrorUserAddPostViewModel model, IFormFile ProfileImage)
        {
            //Save Image(File) In DB
            if (ProfileImage != null)
            {
                using (var fileStore = new MemoryStream())
                {
                    await ProfileImage.CopyToAsync(fileStore);
                    model.UserCreateDto.ProfileImgUser = fileStore.ToArray();
                }
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var SentModel = await _IUserServices.AddPost(model.UserCreateDto, userId);
            if (!SentModel.IsFalid)
            {
                //ViewBag.ResError = SentModel.ResultError;
                TempData["ResError"] = $"e: {SentModel.ResultError}";
                return View(SentModel);
            }
            TempData["ResError"] = $"s: لقد تم إضافة المستخدم بنجاح.";
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // To SingnIn User After register And Return Home Page With Login
               await _SignInManager
              .PasswordSignInAsync(model.UserCreateDto.Email, model.UserCreateDto.Password, false, false);
                return Redirect("~/Home/Index");
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            var GetModel = await _IUserServices.EditGet(Id);
            if (!GetModel.IsFalid)
            {
                return NotFound();
            }
            return View(GetModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] ErrorUserAddPostViewModel model, IFormFile ProfileImage)
        {
            ErrorOrgnizeEdit ModelOrg = new ErrorOrgnizeEdit();
            ErrorUserAddPostViewModel ModelUser = new ErrorUserAddPostViewModel();
            if (ProfileImage != null)
            {
                using (var fileStore = new MemoryStream())
                {
                    await ProfileImage.CopyToAsync(fileStore);
                    model.UserCreateDto.ProfileImgUser = fileStore.ToArray();
                }
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

            if (model.UserCreateDto.NumOrgnization != null)
            {
                var NewModel = new OrgnizationEditDto
                {
                    Email = model.UserCreateDto.Email,
                    FullName = model.UserCreateDto.FullName,
                    ProfileImgUser = model.UserCreateDto.ProfileImgUser,
                    PhoneNumber = model.UserCreateDto.PhoneNumber,
                    AllRoles = model.UserCreateDto.AllRoles,
                    Id = (int)model.UserCreateDto.NumOrgnization
                };
                ModelOrg = await _OrgServices.EditPost(NewModel, userId);
                ModelUser.IsFalid = true;
            }
            else
            {
                ModelUser = await _IUserServices.EditPost(model.UserCreateDto, userId);
                ModelOrg.IsFalid = true;
            }


            if (!ModelOrg.IsFalid)
            {
                //ViewBag.ResError = ModelOrg.ResultError;
                TempData["ResError"] = $"e: {ModelOrg.ResultError}";
                return View(ModelOrg);
            }
            else if (!ModelUser.IsFalid)
            {
                //ViewBag.ResError = ModelOrg.ResultError;
                TempData["ResError"] = $"e: {ModelUser.ResultError}";

                return View(ModelUser);
            }

            TempData["ResError"] = $"s: لقد تم تعديل المستخدم بنجاح.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string Id)
        {
            var GetUser = await _IUserServices.ReturnUser(Id);
            if (GetUser.NumOrgnization != null)
            {
                TempData["ResError"] = $"e:عزيزي لا يمكن حذف هذا المستخدم لأنه مدير شركة، يجب حذف شركته ثم حذفه!";
                return RedirectToAction(nameof(Index));
            }


            var SetModel = await _IUserServices.Delete(Id);
            if (!SetModel.IsValid)
            {
                return NotFound();
            }
            TempData["ResError"] = "s:لقد تم حذف المستخدم بنجاح.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Excel()
        {
            var content = await _IUserServices.ToExcel();

            return File(
               content,
               "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
               $"{"report"}-{DateTime.Now:d}.xlsx"
           );
        }



    }
}
