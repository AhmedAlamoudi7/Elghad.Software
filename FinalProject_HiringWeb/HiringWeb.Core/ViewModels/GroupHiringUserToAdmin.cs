using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.ViewModels
{
    public class GroupHiringUserToAdmin
    {
        public string Title { get; set; }
        public List<GetApplyingOrdersToUserViewModel> AllHiringOrders { get; set; }
    }
}
