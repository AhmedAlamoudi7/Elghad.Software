using HiringWeb.Core.ModelaDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.ViewModels
{
    public class DisplayGroup
    {
        public string Title { get; set; }
        public List<HiringOrderUserViewModel> AllHiringOrders { get; set; }
    }
}
