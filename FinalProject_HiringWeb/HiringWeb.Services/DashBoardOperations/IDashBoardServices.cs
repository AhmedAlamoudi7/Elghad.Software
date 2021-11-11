using HiringWeb.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Services.DashBoardOperations
{
    public interface IDashBoardServices
    {
        Task<MainDataDashBoardViewModel> GetDataDashBoard();
        Task<List<int>> GetUserType();
        Task<List<int>> GethiringOrderType();
        Task<List<int>> GethiringOrderPublishByMonth();
        Task<List<int>> GethiringOrderApplyingByMonth();
    }
}
