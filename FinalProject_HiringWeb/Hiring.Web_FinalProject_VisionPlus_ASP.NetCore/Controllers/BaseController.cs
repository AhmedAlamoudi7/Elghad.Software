using HiringWeb.Services.NotificationsOperations;
using HiringWeb.Services.UserOperations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUserServices _UserOperation;
        public readonly INotificationServices _INotificationServices;
        protected string UserId;
        public BaseController(IUserServices UserOperation, INotificationServices INotificationServices)
        {
            _UserOperation = UserOperation;
            _INotificationServices = INotificationServices;
        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
            if (User.Identity.IsAuthenticated)
            {
                var GetUser = _UserOperation.ReturnUserByUsreNmae(User.Identity.Name);
                ViewBag.Email = GetUser.Email;
                ViewBag.UserName = GetUser.UserName;
                ViewBag.FullName = GetUser.FullName;
                ViewBag.TypeUsre = GetUser.TypeUser;
                ViewBag.ProfileImg = GetUser.ProfileImgUser;
                UserId = GetUser.Id;
            }
            
            return base.OnActionExecutionAsync(context, next);
        }
    }
}
