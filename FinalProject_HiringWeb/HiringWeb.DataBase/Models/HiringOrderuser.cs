using HiringWeb.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.DataBase.Models
{
    public class HiringOrderuser
    {
        public string UserId { get; set; }
        public UserApplication User { get; set; }
        public int HiringOrderId { get; set; }
        public HiringOrder HiringOrder { get; set; }
        public DateTime CreateAt { get; set; }
        public bool IsDelete { get; set; }
        public StatusHiringOrderEnum StatusType { get; set; }
    }
}
