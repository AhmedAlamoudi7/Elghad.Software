using HiringWeb.Core.Enums;
using HiringWeb.Core.ModelaDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.ViewModels
{
    public class NotificateDetailsOrgApplicantViewModel
    {
        public StatusHiringOrderEnum StatusType { get; set; }
        public DateTime CreateAt { get; set; }
        public HiringOrderAllPropViewModel HiringOrder { get; set; }
        public UserApplicationViewModel User { get; set; }

    }
}
