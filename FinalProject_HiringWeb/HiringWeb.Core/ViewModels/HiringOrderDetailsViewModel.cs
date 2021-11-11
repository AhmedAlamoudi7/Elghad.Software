using HiringWeb.Core.Enums;
using HiringWeb.Core.ModelaDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.ViewModels
{
    public class HiringOrderDetailsViewModel
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public double Salary { get; set; }
        public String Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreateAt { get; set; }
        public StatusHiringOrderEnum OrderStatus { get; set; }
        public orgnizationViewModel Orgnization { get; set; }
        public List<HiringOrderAttachmentViewModel> AllAttachments { get; set; }
    }
}
