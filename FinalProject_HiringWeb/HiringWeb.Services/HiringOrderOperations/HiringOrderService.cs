using AutoMapper;
using Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Data;
using HiringWeb.Core.DTO;
using HiringWeb.Core.Enums;
using HiringWeb.Core.ModelaDB;
using HiringWeb.Core.ViewModels;
using HiringWeb.DataBase.Models;
using HiringWeb.Services.FileOperations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringWeb.Services.HiringOrderOperations
{
    public class HiringOrderService : IHiringOrderService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _Mapper;
        private readonly IFileServices _FileServices;
        public HiringOrderService(ApplicationDbContext db,
                                   IMapper Mapper, IFileServices FileServices)
        {
            _db = db;
            _Mapper = Mapper;
            _FileServices = FileServices;
        }

        public async Task<HiringOrderPaginationIndex> Index(int PageNum, string SearchWord,
                                         int SelectSize, StatusHiringOrderEnum StatusOrder, UserApplication user)
        {

            // Pagination
            var PageSize = (double)SelectSize;// Number Element In Single Page
            if (SelectSize == 0)
            {
                PageSize = 5.0;
            }

            var NumberPage = Math.Ceiling(_db.HiringOrder.Include(a => a.Orgnization).Where
                                                   (a => !a.IsDelete &&
                                                   (a.Title.Contains(SearchWord) ||
                                                    a.OrderStatus == StatusOrder ||
                                                    a.Orgnization.Name.Contains(SearchWord) ||
                                                    (string.IsNullOrEmpty(SearchWord) && StatusOrder == 0)
                                                    )).Count() / PageSize); // Number Pages

            if (PageNum < 1 || PageNum > NumberPage)
            {
                PageNum = 1;
            }
            var SkipRow = (int)((PageNum - 1) * PageSize);

            // All Hiring Order To User Admin 
            var AllHireOrder = _db.HiringOrder.Include(a => a.Orgnization).Include(x => x.AllUsers).Where
                                                   (a => !a.IsDelete &&
                                                   (a.Title.Contains(SearchWord) ||
                                                    a.OrderStatus == StatusOrder ||
                                                    a.Orgnization.Name.Contains(SearchWord) ||
                                                    (string.IsNullOrEmpty(SearchWord) && StatusOrder == 0))).AsQueryable();
            // Hiring Order Private To Current user Type(OrgnisationAdmin)
            if (user.TypeUser == "OrgnisationAdmin")
            {
                AllHireOrder = AllHireOrder.Where(a => a.OrgnizationId == user.NumOrgnization);
                NumberPage = Math.Ceiling(AllHireOrder.Count() / PageSize);
            }

            var SendAllHireOrder = await AllHireOrder.Skip(SkipRow).Take((int)PageSize)
                                                .Select(order => new HiringOrderIndexViewModel
                                                {
                                                    Id = order.Id,
                                                    Title = order.Title,
                                                    Deadline = order.Deadline,
                                                    Salary = order.Salary,
                                                    OrderStatus = order.OrderStatus,
                                                    OrgnizationName = order.Orgnization.Name,
                                                    NumApplicants = order.AllUsers.Count()
                                                }).ToListAsync();



            return new HiringOrderPaginationIndex
            {
                NumberPage = (int)NumberPage, // Number Pages For All Return Rows
                AllHiringOrders = SendAllHireOrder, // Return All Row(All Data)
                SentPageNum = PageNum // Set Number Page Choosen
            };
        }

        public async Task<SelectList> AddGet()
        {
            var ListOrg = new SelectList(_db.orgnization.Where(a => !a.IsDelete), "Id", "Name");
            return ListOrg;
        }

        public async Task<bool> AddPost(HiringOrderAddDto AddHireOrder, string userId)
        {
            var AddHiringOrd = _Mapper.Map<HiringOrder>(AddHireOrder);
            AddHiringOrd.CreateBy = userId;
            AddHiringOrd.OrderStatus = StatusHiringOrderEnum.Pending;
            await _db.HiringOrder.AddAsync(AddHiringOrd);
            await _db.SaveChangesAsync();

            // Save Name Job Image In DB And Store File In Folder On Server
            if (AddHireOrder.JobImg != null)
            {
                var FileName = await _FileServices.SaveFile(AddHireOrder.JobImg, "AllFiles");
                AddHiringOrd.HiringImg = FileName;
                _db.HiringOrder.Update(AddHiringOrd);
                await _db.SaveChangesAsync();
            }
            // Save Name Attachment In DB And Store File In Folder On Server
            if (AddHireOrder.Attachments != null)
            {
                foreach (var file in AddHireOrder.Attachments)
                {
                    var FileName = await _FileServices.SaveFile(file, "AllFiles");
                    var AddAttachment = new HiringOrderAttachment
                    {
                        AttachmentUrl = FileName,
                        HiringOrderId = AddHiringOrd.Id
                    };
                    await _db.HiringOrderAttachment.AddAsync(AddAttachment);
                    await _db.SaveChangesAsync();
                }
            }

            //Start Store Notification In Table NotificationDbEntity IN DB (Evaluation Applicant)
            var AdminId = await _db.Users.SingleOrDefaultAsync(a => a.FullName == "Admin System");

            var NotificationgData = new NotificationsDbEntity()
            {
                UserSubjectId = userId, // Id To New User
                UserObjectId = AdminId.Id, // Id To Admin
                HiringOrderId = AddHiringOrd.Id,
                NotificationTime = DateTime.Now,
                NotificationType = NotificationTypeEnum.JobPublish
            };
            await _db.NotificationsDbEntity.AddAsync(NotificationgData);
            await _db.SaveChangesAsync();
            //End

            return true;
        }

        public async Task<HiringOrderEditDto> EditGet(int Id)
        {
            var GetHireOrd = await _db.HiringOrder.Include(a => a.Orgnization).SingleOrDefaultAsync(a => a.Id == Id && !a.IsDelete);
            var EditGetHiringOrd = _Mapper.Map<HiringOrderEditDto>(GetHireOrd);
            return EditGetHiringOrd;
        }

        public async Task<bool> EditPost(HiringOrderEditDto EditHireOrder, string userId)
        {
            var GetHireOrd = await _db.HiringOrder.Include(a => a.Orgnization)
                .SingleOrDefaultAsync(a => a.Id == EditHireOrder.Id && !a.IsDelete);

            var EditHiringOrd = _Mapper.Map(EditHireOrder, GetHireOrd);
            _db.HiringOrder.Update(EditHiringOrd);
            _db.SaveChanges();
            return true;
        }

        public async Task<HiringOrderDetailsViewModel> Details(int Id)
        {
            var Order = await _db.HiringOrder.Include(a => a.Orgnization)
                                             .Include(a => a.AllAttachments)
                                             .SingleOrDefaultAsync(a => !a.IsDelete && a.Id == Id);
            return _Mapper.Map<HiringOrderDetailsViewModel>(Order);
        }

        public async Task<bool> Delete(int Id)
        {
            var GetHireOrd = await _db.HiringOrder.SingleOrDefaultAsync(a => a.Id == Id && !a.IsDelete);

            if (GetHireOrd == null)
            {
                return false;
            }
            // Delete Hiring Order
            GetHireOrd.IsDelete = true;
            _db.HiringOrder.Update(GetHireOrd);
            _db.SaveChanges();
            return true;
        }

        public async Task<EvaluateOrder> ReturnHiringOrder(int Id, StatusHiringOrderEnum status, string UserId)
        {
            var Order = await _db.HiringOrder.Include(a => a.Orgnization).SingleOrDefaultAsync(a => !a.IsDelete && a.Id == Id);
            if (Order != null)
            {
                Order.OrderStatus = status;
                _db.Update(Order);
                _db.SaveChanges();

                //Start Store Notification In Table NotificationDbEntity IN DB (Evaluation Applicant)
                var NotificationgData = new NotificationsDbEntity()
                {
                    UserSubjectId = UserId,
                    UserObjectId = Order.Orgnization.UserId,
                    HiringOrderId = Id,
                    NotificationTime = DateTime.Now,
                    NotificationType = NotificationTypeEnum.Evaluation,
                    NotificationTypeDes = status.ToString()
                };
                await _db.NotificationsDbEntity.AddAsync(NotificationgData);
                await _db.SaveChangesAsync();
                //End

                return new EvaluateOrder
                {
                    IsValid = true,
                    OrderName = Order.Title,
                    Email = Order.Orgnization.Email
                };
            }
            return new EvaluateOrder { IsValid = false };
        }

        public string ConvertOrederArabic(StatusHiringOrderEnum order)
        {
            string OrderArabic = string.Empty;
            switch (order)
            {
                case StatusHiringOrderEnum.Pending:
                    OrderArabic = "قيد الإنتظار";
                    break;
                case StatusHiringOrderEnum.Approved:
                    OrderArabic = "قبول";
                    break;
                case StatusHiringOrderEnum.Rejected:
                    OrderArabic = "رفض";
                    break;
            }
            return OrderArabic;
        }

        // **************** Start Orgnization Admin Services **************** :
        public async Task<List<HiringOrderuser>> GetUsersApplyingForOrder(int Id)
        {
            var AllUsers = await _db.HiringOrderuser.Include(x => x.User).Include(z => z.HiringOrder)
                                    .Where(a => a.HiringOrderId == Id).ToListAsync();
            return AllUsers;

            //.Select(obj => obj.User).ToListAsync();
            //return _Mapper.Map<List<GetUsersApplyingOrderViewModel>>(AllUsers);
        }

        public async Task<HiringOrderuser> EvalApplicatin(string UserId, int HiringOrdId, StatusHiringOrderEnum status, string CurrentUserId)
        {
            var Oreder = await _db.HiringOrderuser.Include(a => a.User).Include(z => z.HiringOrder)
                                .SingleOrDefaultAsync(a => a.UserId == UserId && a.HiringOrderId == HiringOrdId);
            Oreder.StatusType = status;
            _db.HiringOrderuser.Update(Oreder);
            await _db.SaveChangesAsync();

            //Start Store Notification In Table NotificationDbEntity IN DB (Evaluation Applicant)
            var NotificationgData = new NotificationsDbEntity()
            {
                UserSubjectId = CurrentUserId,
                UserObjectId = UserId,
                HiringOrderId = HiringOrdId,
                NotificationTime = DateTime.Now,
                NotificationType = NotificationTypeEnum.Evaluation,
                NotificationTypeDes = status.ToString()
            };
            await _db.NotificationsDbEntity.AddAsync(NotificationgData);
            await _db.SaveChangesAsync();
            //End

            return Oreder;
        }

        public async Task<List<DisplayGroup>> EvalApplicatin(int OrgId)
        {
            var Oreder = await _db.HiringOrderuser.Include(a => a.User).Include(z => z.HiringOrder)
                                   .Where(x => (x.StatusType == StatusHiringOrderEnum.Approved ||
                                                x.StatusType == StatusHiringOrderEnum.Rejected) &&
                                                x.HiringOrder.OrgnizationId == OrgId).ToListAsync();

            // Display Hiring Order Is Evaluation As Group By Title
            return Oreder.GroupBy(z => z.HiringOrder.Title)
                .Select(x => new DisplayGroup
                {
                    Title = x.Key,
                    AllHiringOrders = _Mapper.Map<List<HiringOrderUserViewModel>>(x.ToList())
                }).ToList();
        }

        public async Task<List<DisplayGroup>> NotEvalApplicatin(int OrgId)
        {
            var Oreder = await _db.HiringOrderuser.Include(a => a.User).Include(z => z.HiringOrder)
                                   .Where(x => x.StatusType == StatusHiringOrderEnum.Pending &&
                                                x.HiringOrder.OrgnizationId == OrgId).ToListAsync();

            // Display Hiring Order Is Evaluation As Group By Title
            return Oreder.GroupBy(z => z.HiringOrder.Title)
                .Select(x => new DisplayGroup
                {
                    Title = x.Key,
                    AllHiringOrders = _Mapper.Map<List<HiringOrderUserViewModel>>(x.ToList())
                }).ToList();
        }
        // **************** End Orgnization Admin Services ****************


        // **************** Start DashBoard To Current Orgnization **************** :
        public DashBoardOrgnization DashBoardOrgnization(int OrgId)
        {
            return new DashBoardOrgnization
            {
                NumHiringOrderPublishe = _db.HiringOrder.Where(a => !a.IsDelete && a.OrgnizationId == OrgId).Count(),

                NumApplicants = _db.HiringOrderuser.Include(a => a.HiringOrder)
                                                   .Where(x => x.HiringOrder.OrgnizationId == OrgId).Count(),

                NumOrderEvaluation = _db.HiringOrderuser.Include(z => z.HiringOrder)
                                   .Where(x => (x.StatusType == StatusHiringOrderEnum.Approved ||
                                                x.StatusType == StatusHiringOrderEnum.Rejected) &&
                                                x.HiringOrder.OrgnizationId == OrgId).Count(),

                NumOrderNotEvaluation = _db.HiringOrderuser.Include(z => z.HiringOrder)
                                   .Where(x => x.StatusType == StatusHiringOrderEnum.Pending &&
                                                x.HiringOrder.OrgnizationId == OrgId).Count()
            };
        }

        public List<int> EvalHiringOrderByAdmin(int OrgId)
        {
            var Data = new List<int>();
            Data.Add(_db.HiringOrder.Where(a => !a.IsDelete && a.OrgnizationId == OrgId && a.OrderStatus == StatusHiringOrderEnum.Pending).Count());
            Data.Add(_db.HiringOrder.Where(a => !a.IsDelete && a.OrgnizationId == OrgId && a.OrderStatus == StatusHiringOrderEnum.Approved).Count());
            Data.Add(_db.HiringOrder.Where(a => !a.IsDelete && a.OrgnizationId == OrgId && a.OrderStatus == StatusHiringOrderEnum.Rejected).Count());
            return Data;
        }
        public List<int> EvalApplicantsByOrgnization(int OrgId)
        {
            var Data = new List<int>();
            Data.Add(_db.HiringOrderuser.Include(x => x.HiringOrder)
                .Where(a => a.StatusType == StatusHiringOrderEnum.Pending && a.HiringOrder.OrgnizationId == OrgId).Count());
            Data.Add(_db.HiringOrderuser.Include(x => x.HiringOrder)
               .Where(a => a.StatusType == StatusHiringOrderEnum.Approved && a.HiringOrder.OrgnizationId == OrgId).Count());
            Data.Add(_db.HiringOrderuser.Include(x => x.HiringOrder)
               .Where(a => a.StatusType == StatusHiringOrderEnum.Rejected && a.HiringOrder.OrgnizationId == OrgId).Count());
            return Data;
        }
        public List<int> hiringOrderPublishByMonth(int OrgId)
        {
            var Data = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                Data.Add(_db.HiringOrder.Where(a => !a.IsDelete && a.CreateAt.Date.Month == i && a.OrgnizationId == OrgId).Count());
            }
            return Data;
        }
        public List<int> hiringOrderApplyingByMonth(int OrgId)
        {
            var Data = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                Data.Add(_db.HiringOrderuser.Include(x => x.HiringOrder)
                    .Where(a => a.CreateAt.Date.Month == i && a.HiringOrder.OrgnizationId == OrgId).Count());
            }
            return Data;
        }

        // **************** End DashBoard To Current Orgnization **************** 


        // **************** Start Applicant Services **************** :
        // Return All Applying Hiring To Current User
        public async Task<List<GetApplyingOrdersToUserViewModel>> GetApplyingOrdersToUser(string Id)
        {
            var AllOrders = await _db.HiringOrderuser.Include(z => z.HiringOrder).ThenInclude(a => a.Orgnization)
                                    .Where(a => a.UserId == Id && !a.IsDelete).ToListAsync();

            return _Mapper.Map<List<GetApplyingOrdersToUserViewModel>>(AllOrders);

        }

        //Return All Evaluation Applying Hiring To Current User
        public async Task<List<GroupOrderToUser>> GetEvalApplyingOrdersToUser(string Id)
        {
            var AllOrders = await _db.HiringOrderuser.Include(z => z.HiringOrder).ThenInclude(a => a.Orgnization)
                                    .Where(a => a.UserId == Id && !a.IsDelete &&
                                    (a.StatusType == StatusHiringOrderEnum.Approved
                                    || a.StatusType == StatusHiringOrderEnum.Rejected)).ToListAsync();

            var NewAllOrders = _Mapper.Map<List<GetApplyingOrdersToUserViewModel>>(AllOrders);

            var ReturnOrders = NewAllOrders.GroupBy(z => z.StatusType)
            .Select(x => new GroupOrderToUser
            {
                Title = x.Key,
                AllHiringOrders = x.ToList()
            }).ToList();

            return ReturnOrders;
        }

        //Return All Not Evaluation Applying Hiring To Current User
        public async Task<List<GroupOrderToUser>> GetNotEvalApplyingOrdersToUser(string Id)
        {
            var AllOrders = await _db.HiringOrderuser.Include(z => z.HiringOrder).ThenInclude(a => a.Orgnization)
                                    .Where(a => a.UserId == Id && !a.IsDelete &&
                                    a.StatusType == StatusHiringOrderEnum.Pending).ToListAsync();

            var NewAllOrders = _Mapper.Map<List<GetApplyingOrdersToUserViewModel>>(AllOrders);

            var ReturnOrders = NewAllOrders.GroupBy(z => z.StatusType)
            .Select(x => new GroupOrderToUser
            {
                Title = x.Key,
                AllHiringOrders = x.ToList()
            }).ToList();

            return ReturnOrders;

        }

        // Return Single HiringOrderUser By PK (To Action Method Details)
        public async Task<GetApplyingOrdersToUserViewModel> GetHiringOrderUser(string UserId, int OrderId)
        {
            var AllOrders = await _db.HiringOrderuser.Include(z => z.HiringOrder)
                                                     .ThenInclude(a => a.Orgnization)
                                                     .Include(z => z.HiringOrder)
                                                     .ThenInclude(a => a.AllAttachments)
                                    .SingleOrDefaultAsync(a => a.UserId == UserId && !a.IsDelete && a.HiringOrderId == OrderId);

            return _Mapper.Map<GetApplyingOrdersToUserViewModel>(AllOrders);

        }

        // Delete Single HiringOrderUser By PK (To Action Method Delete)
        public async Task<bool> DeleteHiringOrdUser(string UserId, int OrderId)
        {
            var AllOrders = await _db.HiringOrderuser.SingleOrDefaultAsync
                (a => a.UserId == UserId && a.HiringOrderId == OrderId && !a.IsDelete);
            if (AllOrders == null) { return false; }
            AllOrders.IsDelete = true;
            _db.HiringOrderuser.Update(AllOrders);
            await _db.SaveChangesAsync();
            return true;
        }

        // **************** End Applicant Services ****************

        // Return All HiringOrderUser To Admin (Index Display All)
        public async Task<List<GroupHiringUserToAdmin>> GetAllHiringOrderUserToAdmin()
        {
            var AllOrders = await _db.HiringOrderuser.Include(z => z.User).Include(z => z.HiringOrder)
                                                     .ThenInclude(a => a.Orgnization)
                                                     .Where(a => !a.IsDelete)
                                                     .ToListAsync();


            var NewAllOrders = _Mapper.Map<List<GetApplyingOrdersToUserViewModel>>(AllOrders);
            var GroupByHiringUser = NewAllOrders.GroupBy(a => a.HiringOrder.Title)
                .Select(data => new GroupHiringUserToAdmin
                {
                    Title = data.Key,
                    AllHiringOrders = data.ToList()
                }).ToList();

            return GroupByHiringUser;
        }

        // Return Single HiringOrderUser To Admin  (Details)
        public async Task<GetApplyingOrdersToUserViewModel> GetHiringOrderUserToAdminDetails(string UserId, int OrderId)
        {
            var AllOrders = await _db.HiringOrderuser.Include(z => z.User).Include(z => z.HiringOrder)
                                                     .ThenInclude(a => a.Orgnization)
                                                     .Include(z => z.HiringOrder)
                                                     .ThenInclude(a => a.AllAttachments)
                                    .SingleOrDefaultAsync(a => a.UserId == UserId && !a.IsDelete && a.HiringOrderId == OrderId);

            return _Mapper.Map<GetApplyingOrdersToUserViewModel>(AllOrders);

        }

        //*********************** Start Serevice Applying For Job *********************** :
        public async Task<AllHiringOrdHomePagePagination> AllHiringOrdHomePage(int PageNum, string SearchWord)
        {
            var PageSize = 8.0;// Number Element In Single Page

            var NumberPages = Math.Ceiling(_db.HiringOrder.Where
                                          (a => !a.IsDelete && a.OrderStatus == StatusHiringOrderEnum.Approved
                                           && a.Deadline >= DateTime.Now
                                           && (a.Title.Contains(SearchWord) || string.IsNullOrEmpty(SearchWord)))
                                              .Count() / PageSize);


            if (PageNum < 1 || PageNum > NumberPages)
            {
                PageNum = 1;
            }
            var SkipRow = (int)((PageNum - 1) * PageSize);
            var AllHiringOrd = await _db.HiringOrder.Where
                                          (a => !a.IsDelete && a.OrderStatus == StatusHiringOrderEnum.Approved
                                       && a.Deadline >= DateTime.Now
                                       && (a.Title.Contains(SearchWord) || string.IsNullOrEmpty(SearchWord)))
                                          .Skip(SkipRow).Take((int)PageSize).ToListAsync();

            var NewAllHiringOrd = _Mapper.Map<List<AllHiringOrdHomePageViewModel>>(AllHiringOrd);

            return new AllHiringOrdHomePagePagination
            {
                NumberPages = (int)NumberPages,
                SentPageNum = PageNum,
                AllHiringOrders = NewAllHiringOrd
            };
        }

        public async Task<HiringOrderDetailsViewModel> HomePageDetailsOrder(int Id)
        {
            var HiringOrd = await _db.HiringOrder.Include(a => a.Orgnization).Include(x => x.AllAttachments)
                                    .SingleOrDefaultAsync(a => !a.IsDelete && a.Id == Id);
            return _Mapper.Map<HiringOrderDetailsViewModel>(HiringOrd);
        }

        public async Task<ErrorUser> ApplyingForJob(string UserId, int OrdId)
        {
            // Check If Same User Applying Same Jobs Another One
            var CheckApplySameJob = _db.HiringOrderuser.Any
                                                (a => a.UserId == UserId && a.HiringOrderId == OrdId);
            if (CheckApplySameJob)
            {
                return new ErrorUser() { IsValid = false, ErrorMessage = "e:عزيزي لقد تقدمت لهذه الوظيفة مسبقاً!" };
            }

            // Check If Orgnization Publish This Job Want Applying Your Job
            var CheckOrg = await _db.HiringOrder.Include(x => x.Orgnization).SingleOrDefaultAsync
                                    (a => a.Orgnization.UserId == UserId && a.Id == OrdId);
            if (CheckOrg != null)
            {
                return new ErrorUser() { IsValid = false, ErrorMessage = "e:عزيزي أنت من قمت بنشر الوظيفة لا يمكن التقدم لها!" };
            }

            var Applicant = new HiringOrderuser
            {
                UserId = UserId,
                HiringOrderId = OrdId,
                CreateAt = DateTime.Now,
                StatusType = StatusHiringOrderEnum.Pending
            };
            await _db.HiringOrderuser.AddAsync(Applicant);
            await _db.SaveChangesAsync();
            //Start Store Notification In Table NotificationDbEntity IN DB (Applying Job)
            var GetOrg = await _db.HiringOrder.Include(z => z.Orgnization)
                                .SingleOrDefaultAsync(a => a.Id == OrdId);

            var NotificationgData = new NotificationsDbEntity()
            {
                UserSubjectId = UserId,
                UserObjectId = GetOrg.Orgnization.UserId,
                HiringOrderId = OrdId,
                NotificationTime = DateTime.Now,
                NotificationType = NotificationTypeEnum.Applicant
            };
            await _db.NotificationsDbEntity.AddAsync(NotificationgData);
            await _db.SaveChangesAsync();
            //End
            return new ErrorUser() { IsValid = true, ErrorMessage = "s:لقد تقدمت للوظيفة بنجاح!" };
        }

        //*********************** End Service Applying For Job *********************** :
    }
}
