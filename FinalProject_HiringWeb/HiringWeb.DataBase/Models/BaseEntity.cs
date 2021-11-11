using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.DataBase.Models
{
    public class BaseEntity
    {
        public bool IsDelete { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public string CreateBy { get; set; }

        public string UpdateBy { get; set; }


        public BaseEntity()
        {
            CreateAt = DateTime.Now;
        }
    }
}
