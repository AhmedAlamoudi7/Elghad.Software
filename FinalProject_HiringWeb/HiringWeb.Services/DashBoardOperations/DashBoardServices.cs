using Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Data;
using HiringWeb.Core.Enums;
using HiringWeb.Core.ViewModels;
using HiringWeb.DataBase.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Services.DashBoardOperations
{
    public class DashBoardServices : IDashBoardServices
    {
        private readonly ApplicationDbContext _db;
        public DashBoardServices(ApplicationDbContext db, UserManager<UserApplication> userManage)
        {
            _db = db;
        }

        public async Task<MainDataDashBoardViewModel> GetDataDashBoard()
        {
            var NumberUsers = _db.Users.Where(a => !a.IsDelete).Count();
            var NumberApplicants = _db.HiringOrderuser.Count();
            var NumberHiringOrders = _db.HiringOrder.Where(a => !a.IsDelete).Count();
            var NumberCompanys = _db.orgnization.Where(a => !a.IsDelete).Count();

            return new MainDataDashBoardViewModel
            {
                NumberUsers = NumberUsers,
                NumberApplicants = NumberApplicants,
                NumberHiringOrders = NumberHiringOrders,
                NumberCompanys = NumberCompanys
            };
        }
        public async Task<List<int>> GetUserType()
        {
            var AdminId = await _db.Roles.SingleOrDefaultAsync(a => a.Name == "Admin");
            var AdminOrgId = await _db.Roles.SingleOrDefaultAsync(a => a.Name == "OrgnisationAdmin");
            var ApplicantId = await _db.Roles.SingleOrDefaultAsync(a => a.Name == "Applicant");

            var Data = new List<int>();
            Data.Add(_db.UserRoles.Where(a => a.RoleId == AdminId.Id).Count());//Admin
            Data.Add(_db.UserRoles.Where(a => a.RoleId == AdminOrgId.Id).Count());//Admin Org
            Data.Add(_db.UserRoles.Where(a => a.RoleId == ApplicantId.Id).Count());//Applicant
            return Data;
        }
        public async Task<List<int>> GethiringOrderType()
        {
            var Data = new List<int>();
            Data.Add(_db.HiringOrder.Where(a => !a.IsDelete && a.OrderStatus == StatusHiringOrderEnum.Pending).Count());
            Data.Add(_db.HiringOrder.Where(a => !a.IsDelete && a.OrderStatus == StatusHiringOrderEnum.Approved).Count());
            Data.Add(_db.HiringOrder.Where(a => !a.IsDelete && a.OrderStatus == StatusHiringOrderEnum.Rejected).Count());
            return Data;
        }
        public async Task<List<int>> GethiringOrderPublishByMonth()
        {
            var Data = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                Data.Add(_db.HiringOrder.Where(a => !a.IsDelete && a.CreateAt.Date.Month == i).Count());
            }
            return Data;
        }
        public async Task<List<int>> GethiringOrderApplyingByMonth()
        {
            var Data = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                Data.Add(_db.HiringOrderuser.Where(a => a.CreateAt.Date.Month == i).Count());
            }
            return Data;
        }
    }
}
