using HiringWeb.Core.DTO;
using HiringWeb.Core.Enums;
using HiringWeb.Core.ViewModels;
using HiringWeb.DataBase.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Services.HiringOrderOperations
{
    public interface IHiringOrderService
    {
        Task<HiringOrderPaginationIndex> Index(int PageNum, string SearchWord, int SelectSize,
                                                StatusHiringOrderEnum StatusOrder, UserApplication user);
        Task<SelectList> AddGet();
        Task<bool> AddPost(HiringOrderAddDto AddHireOrder, string userId);
        Task<HiringOrderEditDto> EditGet(int Id);
        Task<bool> EditPost(HiringOrderEditDto EditHireOrder, string userId);
        Task<HiringOrderDetailsViewModel> Details(int Id);
        Task<bool> Delete(int Id);
        Task<EvaluateOrder> ReturnHiringOrder(int Id, StatusHiringOrderEnum status, string UserId);
        string ConvertOrederArabic(StatusHiringOrderEnum order);
        Task<List<HiringOrderuser>> GetUsersApplyingForOrder(int Id);
        Task<HiringOrderuser> EvalApplicatin(string UserId, int HiringOrdId, StatusHiringOrderEnum status, string CurrentUserId);
        Task<List<DisplayGroup>> EvalApplicatin(int OrgId);
        Task<List<DisplayGroup>> NotEvalApplicatin(int OrgId);
        DashBoardOrgnization DashBoardOrgnization(int OrgId);
        List<int> EvalHiringOrderByAdmin(int OrgId);
        List<int> EvalApplicantsByOrgnization(int OrgId);
        List<int> hiringOrderPublishByMonth(int OrgId);
        List<int> hiringOrderApplyingByMonth(int OrgId);
        Task<List<GetApplyingOrdersToUserViewModel>> GetApplyingOrdersToUser(string Id);
        Task<List<GroupOrderToUser>> GetEvalApplyingOrdersToUser(string Id);
        Task<List<GroupOrderToUser>> GetNotEvalApplyingOrdersToUser(string Id);
        Task<GetApplyingOrdersToUserViewModel> GetHiringOrderUser(string UserId, int OrderId);
        Task<bool> DeleteHiringOrdUser(string UserId, int OrderId);
        Task<List<GroupHiringUserToAdmin>> GetAllHiringOrderUserToAdmin();
        Task<GetApplyingOrdersToUserViewModel> GetHiringOrderUserToAdminDetails(string UserId, int OrderId);
        Task<AllHiringOrdHomePagePagination> AllHiringOrdHomePage(int PageNum, string SearchWord);
        Task<HiringOrderDetailsViewModel> HomePageDetailsOrder(int Id);
        Task<ErrorUser> ApplyingForJob(string UserId, int OrdId);

    }
}
