using HiringWeb.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.DataBase.Models
{
    public class HiringOrder : BaseEntity
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public double Salary { get; set; }
        public String Description { get; set; }
        public DateTime Deadline { get; set; }
        public string HiringImg { get; set; }
        public StatusHiringOrderEnum OrderStatus { get; set; }
        public int OrgnizationId { get; set; }
        public orgnization Orgnization { get; set; }
        public List<HiringOrderAttachment> AllAttachments { get; set; }
        public List<HiringOrderuser> AllUsers { get; set; }

    }
}
