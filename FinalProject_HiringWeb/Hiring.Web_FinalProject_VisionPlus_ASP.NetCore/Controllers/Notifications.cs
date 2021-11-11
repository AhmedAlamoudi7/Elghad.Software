using HiringWeb.Services.HiringOrderOperations;
using HiringWeb.Services.NotificationsOperations;
using HiringWeb.Services.UserOperations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Controllers
{
    [Authorize]
    public class Notifications : BaseController
    {
        private readonly INotificationServices _INotificationServices;
        private readonly IHiringOrderService _IHiringOrderService;

        public Notifications(INotificationServices INotificationServices, IHiringOrderService IHiringOrderService,
            IUserServices UserOperation) : base(UserOperation, INotificationServices)
        {
            _INotificationServices = INotificationServices;
            _IHiringOrderService = IHiringOrderService;
        }
        //Get Notifications Applicant
        public async Task<IActionResult> ApplicantNotification()
        {
            return Ok(await _INotificationServices.ApplicantNotifications(UserId));
        }
        //Get Notifications Orgnization Admin
        public async Task<IActionResult> OrgnizationAdminNotification()
        {
            return Ok(await _INotificationServices.OrgAdminNotifications(UserId));
        }
        //Get Notifications Admin
        public async Task<IActionResult> AdminNotificate()
        {
            return Ok(await _INotificationServices.AdminNotifications());
        }

        // Return Details Notificate When Click it (Applicant)
        public async Task<IActionResult> NotificateDetailsApplicant(string ApplicantId, int JobId)
        {
            var Data = await _INotificationServices.NotificateDetailsApplicant(ApplicantId, JobId);
            return View(Data);
        }
        // Return Details Notificate When Click it (Orgnization(When Applicant Any One))
        public async Task<IActionResult> NotificateDetailsOrgApplicant(string ApplicantId, int JobId)
        {
            var Data = await _INotificationServices.NotificateDetailsOrgApplicant(ApplicantId, JobId);
            return View(Data);
        }

        // Return Details Notificate When Click it (Orgnization(When Evaluation My By Admin))
        public async Task<IActionResult> NotificateOrgJobEval(int JobId)
        {
            var Data = await _IHiringOrderService.Details(JobId);
            return View(Data);
        }

        // Return Details Notificate When Click it (Admin(When Register New User))
        public async Task<IActionResult> NotificateAdminNewUser(string userId)
        {
            var Data = await _INotificationServices.NotificateAdminNewUser(userId);
            return View(Data);
        }

        // Return Details Notificate When Click it (Admin(When Orgnization Any Job))
        public async Task<IActionResult> NotificateAdminJobEval(int JobId)
        {
            var Data = await _IHiringOrderService.Details(JobId);
            return View(Data);
        }
    }
}
