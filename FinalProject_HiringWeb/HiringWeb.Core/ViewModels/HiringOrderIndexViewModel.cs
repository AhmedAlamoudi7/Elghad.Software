using HiringWeb.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.ViewModels
{
    public class HiringOrderIndexViewModel
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public double Salary { get; set; }
        public DateTime Deadline { get; set; }
        public StatusHiringOrderEnum OrderStatus { get; set; }
        public string OrgnizationName { get; set; }
        public int NumApplicants { get; set; }

    }
}
