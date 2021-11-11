using HiringWeb.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.ViewModels
{
    public class NotificationOrgAdminVM
    {
        public NotificationTypeEnum NotificationType { get; set; }
        public string ApplicationStatus { get; set; }
        public string JobName { get; set; }
        public DateTime progressTime { get; set; }
        public string UserSubject { get; set; }
        public string UserSubjectId { get; set; }
        public string UserObjectId { get; set; }
        public int JobId { get; set; }
    }
}
