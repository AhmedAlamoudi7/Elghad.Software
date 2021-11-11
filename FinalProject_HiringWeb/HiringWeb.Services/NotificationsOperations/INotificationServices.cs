using HiringWeb.Core.ModelaDB;
using HiringWeb.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Services.NotificationsOperations
{
    public interface INotificationServices
    {
        Task<List<NotificationApplicantVM>> ApplicantNotifications(string UserId);
        Task<List<NotificationOrgAdminVM>> OrgAdminNotifications(string UserId);
        Task<List<NotificationAdminVM>> AdminNotifications();
        Task<NotificateDetailsApplicantViewModel> NotificateDetailsApplicant(string ApplicantId, int JobId);
        Task<NotificateDetailsOrgApplicantViewModel> NotificateDetailsOrgApplicant(string ApplicantId, int JobId);
        Task<UserApplicationViewModel> NotificateAdminNewUser(string userId);
    }
}
