using HiringWeb.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.ViewModels
{
    public class GroupOrderToUser
    {
        public StatusHiringOrderEnum Title { get; set; }
        public List<GetApplyingOrdersToUserViewModel> AllHiringOrders { get; set; }
    }
}
