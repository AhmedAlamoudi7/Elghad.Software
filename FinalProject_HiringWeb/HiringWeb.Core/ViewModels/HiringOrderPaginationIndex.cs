using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.ViewModels
{
    public class HiringOrderPaginationIndex
    {
        public int NumberPage { get; set; }
        public int SentPageNum { get; set; }
        public List<HiringOrderIndexViewModel> AllHiringOrders { get; set; }
    }
}
