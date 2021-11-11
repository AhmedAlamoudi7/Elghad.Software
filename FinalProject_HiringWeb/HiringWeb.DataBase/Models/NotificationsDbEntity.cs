using HiringWeb.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.DataBase.Models
{
    public class NotificationsDbEntity
    {
        public int Id { get; set; }
        public string UserSubjectId { get; set; }
        public string UserObjectId { get; set; }
        public int? HiringOrderId { get; set; }
        public UserApplication UserSubject { get; set; }
        public UserApplication UserObject { get; set; }
        public HiringOrder HiringOrder { get; set; }
        public DateTime NotificationTime { get; set; }
        public NotificationTypeEnum NotificationType { get; set; }
        public string NotificationTypeDes { get; set; }
    }
}
