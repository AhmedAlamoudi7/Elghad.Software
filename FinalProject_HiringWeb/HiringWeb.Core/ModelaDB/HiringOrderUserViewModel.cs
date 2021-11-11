using HiringWeb.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.ModelaDB
{
    public class HiringOrderUserViewModel
    {
        public string UserId { get; set; }
        public UserApplicationViewModel User { get; set; }
        public int HiringOrderId { get; set; }
        public HiringOrderViewModel HiringOrder { get; set; }
        public DateTime CreateAt { get; set; }
        public StatusHiringOrderEnum StatusType { get; set; }
    }
}
