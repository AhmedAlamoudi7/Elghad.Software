using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.ViewModels
{
    public class AllHiringOrdHomePageViewModel
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public DateTime Deadline { get; set; }
        public string HiringImg { get; set; }
    }
}
