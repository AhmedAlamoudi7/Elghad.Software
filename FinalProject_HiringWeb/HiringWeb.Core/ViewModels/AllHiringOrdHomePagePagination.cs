using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.ViewModels
{
    public class AllHiringOrdHomePagePagination
    {
        public int NumberPages { get; set; }
        public int SentPageNum { get; set; }
        public List<AllHiringOrdHomePageViewModel> AllHiringOrders { get; set; }
    }
}
