using HiringWeb.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.ModelaDB
{
   public class HiringOrderUserAllDataViewModel
    {
        public String Title { get; set; }
        public double Salary { get; set; }
        public String Description { get; set; }
        public DateTime Deadline { get; set; }
        public orgnizationViewModel Orgnization { get; set; }
        public List<HiringOrderAttachmentViewModel> AllAttachments { get; set; }
    }
}
