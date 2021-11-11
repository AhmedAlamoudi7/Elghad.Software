using AutoMapper;
using Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Data;
using HiringWeb.Core.Enums;
using HiringWeb.Core.ModelaDB;
using HiringWeb.Core.ViewModels;
using HiringWeb.Services.OrgnizationOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Services.NotificationsOperations
{
    public class NotificationServices : INotificationServices
    {
        private readonly ApplicationDbContext _db;
        private readonly IOrgnizationServices _IOrgnizationServices;
        private readonly IMapper _Mapper;

        public NotificationServices(ApplicationDbContext db, 
                                    IOrgnizationServices IOrgnizationServices,
                                    IMapper Mapper)
        {
            _db = db;
            _IOrgnizationServices= IOrgnizationServices;
            _Mapper = Mapper;
        }

        //Get Notifications Applicants
        public async Task<List<NotificationApplicantVM>> ApplicantNotifications(string UserId)
        {
            var NotData = await _db.NotificationsDbEntity.Include(a => a.HiringOrder)
                                .Where(z => z.UserObjectId == UserId)
                                .OrderByDescending(a => a.Id)
                                .Select(data => new NotificationApplicantVM()
                                {
                                    ApplicationStatus = data.NotificationTypeDes,
                                    JobName = data.HiringOrder.Title,
                                    progressTime = data.NotificationTime,
                                    ApplicantId = data.UserObjectId,
                                    JobId = (int)data.HiringOrderId
                                }).ToListAsync();

            return NotData;
        }

        //Get Notifications Orgnization Admin
        public async Task<List<NotificationOrgAdminVM>> OrgAdminNotifications(string UserId)
        {
            var NotData = await _db.NotificationsDbEntity.Include(a => a.HiringOrder).Include(a => a.UserSubject)
                                .Where(z => z.UserObjectId == UserId && z.UserSubject != null)
                                .OrderByDescending(a => a.Id)
                                .Select(data => new NotificationOrgAdminVM()
                                {
                                    NotificationType = data.NotificationType,
                                    ApplicationStatus = data.NotificationTypeDes,
                                    JobName = data.HiringOrder.Title,
                                    progressTime = data.NotificationTime,
                                    UserSubject = data.UserSubject.FullName,
                                    UserSubjectId = data.UserSubjectId,
                                    UserObjectId = data.UserObjectId,
                                    JobId = (int)data.HiringOrderId
                                }).ToListAsync();

            return NotData;
        }

        //Get Notifications Admin New User
        public async Task<List<NotificationAdminVM>> AdminNotifications()
        {
            var AdminId = await _db.Users.SingleOrDefaultAsync(a => a.FullName == "Admin System");
            var NotData = await _db.NotificationsDbEntity.Include(a => a.HiringOrder).Include(a => a.UserSubject)
                                .Where(z => z.UserObjectId == AdminId.Id)
                                        .OrderByDescending(a => a.Id)
                                .Select(data => new NotificationAdminVM()
                                {
                                    UserSubject = data.UserSubject.FullName,
                                    JobName = data.HiringOrder.Title,
                                    progressTime = data.NotificationTime,
                                    NotificationTypeEnum =data.NotificationType,
                                    UserSubjectId = data.UserSubjectId,
                                    UserObjectId = data.UserObjectId,
                                    JobId = data.HiringOrderId
                                }).ToListAsync();
            return NotData;
        }



        // ======== Return Details Notificate When Click it (Applicant) ======== :
        public async Task<NotificateDetailsApplicantViewModel> NotificateDetailsApplicant(string ApplicantId, int JobId)
        {
            var Data = await _db.HiringOrderuser.Include(x => x.HiringOrder).ThenInclude(x => x.Orgnization).SingleOrDefaultAsync(a => !a.IsDelete &&
                                a.UserId == ApplicantId && a.HiringOrderId == JobId);
            return _Mapper.Map<NotificateDetailsApplicantViewModel>(Data);
        }

        // ======== Return Details Notificate When Click it (Orgnization(When Applicant Any One)) ======== :
        public async Task<NotificateDetailsOrgApplicantViewModel> NotificateDetailsOrgApplicant(string ApplicantId, int JobId)
        {
            var Data = await _db.HiringOrderuser.Include(x => x.HiringOrder).Include(x => x.User).SingleOrDefaultAsync(a => !a.IsDelete &&
                                a.UserId == ApplicantId && a.HiringOrderId == JobId);
            return _Mapper.Map<NotificateDetailsOrgApplicantViewModel>(Data);
        }

        // ======== Return Details Notificate When Click it (Admin(When Register New User)) ======== :
        public async Task<UserApplicationViewModel> NotificateAdminNewUser(string userId)
        {
            var UserDetails = await _db.Users.SingleOrDefaultAsync(x => x.Id == userId && !x.IsDelete);
            return _Mapper.Map<UserApplicationViewModel>(UserDetails);
        }

    }
}
