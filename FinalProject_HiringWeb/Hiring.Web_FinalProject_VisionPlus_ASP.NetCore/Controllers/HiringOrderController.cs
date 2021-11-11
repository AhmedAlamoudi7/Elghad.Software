using HiringWeb.Core.DTO;
using HiringWeb.Core.Enums;
using HiringWeb.Core.ViewModels;
using HiringWeb.Services.EmailOperation;
using HiringWeb.Services.HiringOrderOperations;
using HiringWeb.Services.NotificationsOperations;
using HiringWeb.Services.UserOperations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Controllers
{
    [Authorize]
    public class HiringOrderController : BaseController
    {
        private readonly IHiringOrderService _HiringOrderService;
        private readonly ISendMailServices _SendMailServices;
        private readonly IUserServices _IUserServices;

        public HiringOrderController(IHiringOrderService HiringOrderService, 
            ISendMailServices SendMailServices, IUserServices UserOperation,
            IUserServices IUserServices, INotificationServices INotificationServices) : base(UserOperation, INotificationServices)
        {
            _HiringOrderService = HiringOrderService;
            _SendMailServices = SendMailServices;
            _IUserServices = IUserServices;
        }

        public async Task<IActionResult> Index(int Id, string SearchWord, int SelectSize,
                                                StatusHiringOrderEnum StatusOrder)
        {
            var CurrentUser = await _IUserServices.ReturnUser(UserId);
            var AllHiringOrd = await _HiringOrderService.Index(Id, SearchWord, SelectSize, StatusOrder, CurrentUser);
            ViewBag.SearchWord = SearchWord;
            ViewBag.SelectSize = SelectSize;
            ViewBag.StatusOrder = StatusOrder;
            return View(AllHiringOrd);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewData["AllOrg"] = await _HiringOrderService.AddGet();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm]HiringOrderAddDto model)
        {
            if(!ModelState.IsValid)
            {
                 ModelState.AddModelError("Description", "هذا الحقل مطلوب");
                ViewData["AllOrg"] = await _HiringOrderService.AddGet();
                return View();
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var ResultAdd = await _HiringOrderService.AddPost(model, userId);
            if (!ResultAdd)
            {
                //ViewBag.ResError = "لم يتم إضافة الطلب بنجاح يرجى التأكد من البيانات المدخلة";
                TempData["ResError"] = "e: لم يتم إضافة الطلب بنجاح يرجى التأكد من البيانات المدخلة!";
                return View(model);
            }
            TempData["ResError"] = "s: لقد تم إضافة الطلب بنجاح.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var GetModel = await _HiringOrderService.EditGet(Id);
            if (GetModel == null)
            {
                return NotFound();
            }
            ViewData["AllOrg"] = await _HiringOrderService.AddGet();
            return View(GetModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HiringOrderEditDto model)
        {
         
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

            var SetModel = await _HiringOrderService.EditPost(model, userId);
            if (!SetModel)
            {
                //ViewBag.ResError = "لم يتم تعديل الطلب بنجاح يرجى التأكد من البيانات المدخلة";
                TempData["ResError"] = "e: لم يتم تعديل الطلب بنجاح يرجى التأكد من البيانات المدخلة";
                return View(model);
            }
            TempData["ResError"] = "s: لقد تم تعديل الطلب بنجاح.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int Id)
        {
            var GetOrder = await _HiringOrderService.Details(Id);
            return View(GetOrder);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var OrderDel = await _HiringOrderService.Delete(Id);
            if (!OrderDel)
            {
                return NotFound();
            }
            TempData["ResError"] = "s: لقد تم حذف الطلب بنجاح.";

            return RedirectToAction(nameof(Index));
        }

        // Change Status Hiring Order And Sent Mail To Client Show Result.
        public async Task<IActionResult> EvaluationOrder(int Id, StatusHiringOrderEnum status)
        {
            var GetHiringOrd = await _HiringOrderService.ReturnHiringOrder(Id, status, UserId);
            if(!GetHiringOrd.IsValid)
            {
                //TempData["ResultEvaluOrdDanger"] = "لم يتم تغيير حالة الطلب بنجاح!";
                TempData["ResError"] = "e: لم يتم تغيير حالة الطلب بنجاح!";
                return RedirectToAction(nameof(Index)); 
            }
            TempData["ResError"] = "s: لقد تم تغيير حالة الطلب بنجاح!";

            var ArabicOrd = _HiringOrderService.ConvertOrederArabic(status);
            // Send Email To User
            var StatusSendMail = await _SendMailServices.SendMail("ahmadalmikkawi123@gmail.com",
                                     $"الرد على طلب {GetHiringOrd.OrderName}", $"لقد تم {ArabicOrd} طلبك.");  

            // Check If Email Sended Or Not
            if(StatusSendMail)
            {
                TempData["ResultEvaluOrdSuccess"] = "لقد تم إرسال إيميل للعميل بنتيجة التقييم بنجاح.";

            }
            else
            {
                TempData["ResultEvaluOrdDanger"] = "لم يتم إرسال إيميل للعميل بنتيجة التقييم لوجود مشكلة في بيانات العميل.";
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetUsersApplyingOrder(int Id)
        {
            TempData["HiringOrderId"] = Id;
            var Users = await _HiringOrderService.GetUsersApplyingForOrder(Id);
            return View(Users);
        }

        // Evaluation Applicants From Orgnization Admin Accept Or Rejected
        public async Task<IActionResult> EvaluationApplicants(string UserId, int HiringOrdId, 
                                            StatusHiringOrderEnum status, string ViewName)
        {
            int num;
            var CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(TempData["HiringOrderId"] != null)
            {
                 num = (int)TempData["HiringOrderId"];
            }else
            {
                num = 0;
            }
            
            var EvalOrder = await _HiringOrderService.EvalApplicatin(UserId, HiringOrdId, status, CurrentUserId);
            TempData["ResError"] = "s: لقد تم تغيير حالة الطلب بنجاح!";

            var ArabicOrd = _HiringOrderService.ConvertOrederArabic(status);
            // Send Email To User
            var StatusSendMail = await _SendMailServices.SendMail("ahmadalmikkawi123@gmail.com",
                 $"الرد على وظيفة {EvalOrder.HiringOrder.Title}",
                 $"مرحباً عزيزي / {EvalOrder.User.FullName} لقد تم {ArabicOrd} طلبك في وظيفة {EvalOrder.HiringOrder.Title}");

            // Check If Email Sended Or Not
            if (StatusSendMail)
            {
                TempData["ResultEvaluOrdSuccessMain"] = "s:لقد تم إرسال إيميل للعميل بنتيجة التقييم بنجاح.";

            }
            else
            {
                TempData["ResultEvaluOrdDangerMain"] = "s:لم يتم إرسال إيميل للعميل بنتيجة التقييم لوجود مشكلة في بيانات العميل.";
            }
            switch(ViewName)
            {
                case "GetUsersApplyingOrder":
                    return RedirectToAction("GetUsersApplyingOrder", new { Id = num });
                case "DisplayEvalOrdToOrg":
                    return RedirectToAction("DisplayEvalOrdToOrg");
                case "DisplayNotEvalOrdToOrg":
                    return RedirectToAction("DisplayNotEvalOrdToOrg");
                case "AllHiringOrderUserToAdmin":
                    return RedirectToAction("AllHiringOrderUserToAdmin");
                default:
                    return Redirect("~/Home/Index");
            }
            
        }

        // Dispaly All Evaluation HiringOrders To Current Orgnization
        public async Task<IActionResult> DisplayEvalOrdToOrg ()
        {
            TempData["TitleView"] = "الطلبات المقيَّمة";
            TempData["TypeView"] = 1;
            var CurrentUser = await _IUserServices.ReturnUser(UserId);
            var GetOrders = await _HiringOrderService.EvalApplicatin((int)CurrentUser.NumOrgnization);
            return View(GetOrders);
        }

        // Dispaly All Not Evaluation HiringOrders To Current Orgnization
        public async Task<IActionResult> DisplayNotEvalOrdToOrg()
        {
            TempData["TitleView"] = "الطلبات الغير مقيَّمة";
            TempData["TypeView"] = 2;
            var CurrentUser = await _IUserServices.ReturnUser(UserId);
            var GetOrders = await _HiringOrderService.NotEvalApplicatin((int)CurrentUser.NumOrgnization);
            return View("DisplayEvalOrdToOrg", GetOrders);
        }

        // **************** Start DashBoard To Current Orgnization **************** :
        public async Task<IActionResult> DashBoardOrgnization()
        {
            var CurrentUser = await _IUserServices.ReturnUser(UserId);
            return View(_HiringOrderService.DashBoardOrgnization((int)CurrentUser.NumOrgnization));
        }

        public async Task<IActionResult> EvalHiringOrderByAdmin()
        {
            var CurrentUser = await _IUserServices.ReturnUser(UserId);
            return Ok(_HiringOrderService.EvalHiringOrderByAdmin((int)CurrentUser.NumOrgnization));
        }
        public async Task<IActionResult> EvalApplicantsByOrgnization()
        {
            var CurrentUser = await _IUserServices.ReturnUser(UserId);
            return Ok(_HiringOrderService.EvalApplicantsByOrgnization((int)CurrentUser.NumOrgnization));
        }
        public async Task<IActionResult> hiringOrderPublishByMonth()
        {
            var CurrentUser = await _IUserServices.ReturnUser(UserId);
            return Ok(_HiringOrderService.hiringOrderPublishByMonth((int)CurrentUser.NumOrgnization));
        }
        public async Task<IActionResult> hiringOrderApplyingByMonth()
        {
            var CurrentUser = await _IUserServices.ReturnUser(UserId);
            return Ok(_HiringOrderService.hiringOrderApplyingByMonth((int)CurrentUser.NumOrgnization));
        }
        // **************** End DashBoard To Current Orgnization **************** :

        // Return All Applying Hiring To Current User
        public async Task<IActionResult> DisAllHiringOrderCurrUser()
        {
            return View(await _HiringOrderService.GetApplyingOrdersToUser(UserId));
        }

        // Return All Evaluation Applying Hiring To Current User
        public async Task<IActionResult> DisAllHiringOrderEvalCurrUser()
        {
            TempData["TitleDataUser"] = "الوظائف المقيَّمة";
            return View(await _HiringOrderService.GetEvalApplyingOrdersToUser(UserId));
        }

        // Return All Not Evaluation Applying Hiring To Current User
        public async Task<IActionResult> DisAllHiringOrderNotEvalCurrUser()
        {
            TempData["TitleDataUser"] = "الوظائف قيد الإنتظار";
            return View("DisAllHiringOrderEvalCurrUser", await _HiringOrderService.GetNotEvalApplyingOrdersToUser(UserId));
        }

        // Details HiringOrderUsre To Applicant
        public async Task<IActionResult> DetailsHiringOrderApplicant(string UserId, int OrderId)
        {
            return View(await _HiringOrderService.GetHiringOrderUser(UserId, OrderId));
        }

        // Delete HiringOrderUsre To Applicant
        public async Task<IActionResult> DeleteHiringOrderApplicant(string UserId, int OrderId)
        {

            var OrderDel = await _HiringOrderService.DeleteHiringOrdUser(UserId, OrderId);
            if (!OrderDel)
            {
                return NotFound();
            }
            TempData["ResError"] = "s: لقد تم حذف الطلب بنجاح.";
            //To check If Admin Work Delete Return To All HiringUser To Admin
            if(ViewBag.TypeUsre == "Admin")
            {
                return RedirectToAction(nameof(AllHiringOrderUserToAdmin));
            }
            return RedirectToAction(nameof(DisAllHiringOrderCurrUser));
        }

        // Return All HiringOrderUser To Admin (Index Display All)
        public async Task<IActionResult> AllHiringOrderUserToAdmin()
        {
            return View(await _HiringOrderService.GetAllHiringOrderUserToAdmin());
        }

        // Return Single HiringOrderUser To Admin  (Details)
        public async Task<IActionResult> HiringOrderUserToAdminDetails(string UserId, int OrderId)
        {
            return View(await _HiringOrderService.GetHiringOrderUserToAdminDetails(UserId, OrderId));
        }

        // Details Job In Home Page
        public async Task<IActionResult> DetailsJob(int Id)
        {
            TempData["ActionDetailsJob"] = "Yes";
            var GetOrder = await _HiringOrderService.HomePageDetailsOrder(Id);
            return View("Details", GetOrder);
        }

        // Applying Job Now From Home Page
        public async Task<IActionResult> ApplyingJob(int Id)
        {
            var StatusApplying = await _HiringOrderService.ApplyingForJob(UserId, Id);
            if(StatusApplying.IsValid == true)
            {
                TempData["ResError"] = StatusApplying.ErrorMessage;
                return RedirectToAction("Index","Home");
            }
            else
            {
                TempData["ResError"] = StatusApplying.ErrorMessage;
                return RedirectToAction("DetailsJob", new { Id = Id });
            }
        }
    }
}
