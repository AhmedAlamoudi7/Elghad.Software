using Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Models;
using HiringWeb.Services.DashBoardOperations;
using HiringWeb.Services.HiringOrderOperations;
using HiringWeb.Services.NotificationsOperations;
using HiringWeb.Services.UserOperations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : BaseController
    {
        private readonly IDashBoardServices _IDashBoardServices;
        private readonly IHiringOrderService _IIHiringOrderService;
        private readonly INotificationServices _INotificationServices;

        public HomeController(IDashBoardServices IDashBoardServices, IHiringOrderService IIHiringOrderService,
            INotificationServices INotificationServices, IUserServices UserOperation) : base(UserOperation, INotificationServices)
        {
            _IDashBoardServices = IDashBoardServices;
            _IIHiringOrderService = IIHiringOrderService;
        }
        [AllowAnonymous]
        public IActionResult LandingPage()
        {
            if (User.Identity.IsAuthenticated)
            { 
                ViewBag.CheckAuthontication = ViewBag.FullName;
            }
            
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int PageNum, string SearchWord)
        {
            ViewBag.SearchWord = SearchWord;
            return View(await _IIHiringOrderService.AllHiringOrdHomePage(PageNum, SearchWord));
        }
        public async Task<IActionResult> DashBoardAdmin()
        {
            return View(await _IDashBoardServices.GetDataDashBoard());
        }
        public async Task<IActionResult> GetUserType()
        {
            return Ok(await _IDashBoardServices.GetUserType());
        }
        public async Task<IActionResult> GethiringOrderTypeChart()
        {
            return Ok(await _IDashBoardServices.GethiringOrderType());
        }
        public async Task<IActionResult> GethiringOrderPublishByMonthChart()
        {
            return Ok(await _IDashBoardServices.GethiringOrderPublishByMonth());
        }
        public async Task<IActionResult> GethiringOrderApplyingByMonthChart()
        {
            return Ok(await _IDashBoardServices.GethiringOrderApplyingByMonth());
        }

    }
}
