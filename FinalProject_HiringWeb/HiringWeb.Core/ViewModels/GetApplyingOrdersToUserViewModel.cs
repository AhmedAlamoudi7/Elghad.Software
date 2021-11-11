using HiringWeb.Core.Enums;
using HiringWeb.Core.ModelaDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.ViewModels
{
    public class GetApplyingOrdersToUserViewModel
    {
        public string UserId { get; set; }
        public UserApplicationViewModel User { get; set; }
        public int HiringOrderId { get; set; }
        public HiringOrderUserAllDataViewModel HiringOrder { get; set; }
        public DateTime CreateAt { get; set; }
        public StatusHiringOrderEnum StatusType { get; set; }
        public bool IsDelete { get; set; }
    }
}
