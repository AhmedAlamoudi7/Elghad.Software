using HiringWeb.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.DataBase.Models
{
    public class UserApplication : IdentityUser
    {
        public string FullName { get; set; }
        public byte[] ProfileImgUser { get; set; }
        public string Cv { get; set; }
        public string TypeUser { get; set; }
        public bool IsDelete { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public string CreateBy { get; set; }

        public string UpdateBy { get; set; }

        public int? NumOrgnization { get; set; }

        public List<HiringOrderuser> AllHiringOrders { get; set; }
    }
}
