#pragma checksum "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "00797a6c4b21cdc29b6daff56947710d50d6d584"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HiringOrder_AllHiringOrderUserToAdmin), @"mvc.1.0.view", @"/Views/HiringOrder/AllHiringOrderUserToAdmin.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\_ViewImports.cshtml"
using Hiring.Web_FinalProject_VisionPlus_ASP.NetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\_ViewImports.cshtml"
using Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\_ViewImports.cshtml"
using HiringWeb.DataBase.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\_ViewImports.cshtml"
using HiringWeb.Core.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\_ViewImports.cshtml"
using HiringWeb.Core.DTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\_ViewImports.cshtml"
using HiringWeb.Core.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00797a6c4b21cdc29b6daff56947710d50d6d584", @"/Views/HiringOrder/AllHiringOrderUserToAdmin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8cfb432cd72c8602dead687194425aa001c82e0c", @"/Views/_ViewImports.cshtml")]
    public class Views_HiringOrder_AllHiringOrderUserToAdmin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<GroupHiringUserToAdmin>>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
  
    ViewData["Title"] = "DisplayALLHiringUserAdmin";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""card card-custom"">
    <div class=""card-header flex-wrap border-0 pt-6 pb-0"">
        <div class=""card-title"" data-aos=""fade-left"">
            <h4 class=""card-label"">
                <span class=""d-block pt-5 font-size-h2-lg"">جميع المتقدمين</span>
            </h4>
        </div>
    </div>
    <hr />
    <div class=""card-body"">
");
#nullable restore
#line 17 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
         if (Model.Any())
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
             foreach (var MainGrp in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h2 class=\"d-block pt-5 font-size-h2-lg text-center\" style=\"font-weight:bold;\" data-aos=\"fade-left\">وظيفة/ ");
#nullable restore
#line 21 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
                                                                                                                      Write(MainGrp.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                <div class=""table-responsive"">
                    <table class=""table table-bordered table-striped text-center mt-3"">
                        <thead>
                            <tr class=""bg-primary text-white"">
                                <td>إسم المتقدم</td>
                                <td>وقت إنتهاء التقدم</td>
                                <td>التقييم</td>
                                <td>الشركة الناشرة</td>
                                <td>العمليات</td>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 34 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
                             foreach (var Order in MainGrp.AllHiringOrders)
                            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr data-aos=\"fade-down\">\r\n                                    <td class=\"tab_col_padding\">");
#nullable restore
#line 38 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
                                                           Write(Order.User.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"tab_col_padding\">");
#nullable restore
#line 39 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
                                                           Write(Order.HiringOrder.Deadline.ToString("yyyy-MM-dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"tab_col_padding\">");
#nullable restore
#line 40 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
                                                           Write(Order.StatusType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"tab_col_padding\">");
#nullable restore
#line 41 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
                                                           Write(Order.HiringOrder.Orgnization.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                    <td>
                                        <div class=""dropdown"">
                                            <button class=""btn btn-secondary dropdown-toggle"" type=""button"" id=""MenuProcess"" data-bs-toggle=""dropdown"" aria-expanded=""false"">
                                                عرض العمليات
                                            </button>
                                            <ul class=""dropdown-menu DropdownMenuTable"" aria-labelledby=""MenuProcess"">
                                                <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "00797a6c4b21cdc29b6daff56947710d50d6d5849332", async() => {
                WriteLiteral("تفاصيل");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2460, "~/HiringOrder/HiringOrderUserToAdminDetails?UserId=", 2460, 51, true);
#nullable restore
#line 48 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
AddHtmlAttributeValue("", 2511, Order.UserId, 2511, 13, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 2524, "&OrderId=", 2524, 9, true);
#nullable restore
#line 48 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
AddHtmlAttributeValue("", 2533, Order.HiringOrderId, 2533, 20, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 49 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
                                                 if (Order.StatusType == StatusHiringOrderEnum.Pending)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <li>\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "00797a6c4b21cdc29b6daff56947710d50d6d58411843", async() => {
                WriteLiteral("\r\n                                                            قبول\r\n                                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 7, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2851, "~/HiringOrder/EvaluationApplicants?UserId=", 2851, 42, true);
#nullable restore
#line 52 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
AddHtmlAttributeValue("", 2893, Order.UserId, 2893, 13, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("\r\n                                                                                ", 2906, "&HiringOrdId=", 2988, 95, true);
#nullable restore
#line 53 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
AddHtmlAttributeValue("", 3001, Order.HiringOrderId, 3001, 20, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("\r\n                                                                                ", 3021, "&status=", 3103, 90, true);
#nullable restore
#line 54 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
AddHtmlAttributeValue("", 3111, StatusHiringOrderEnum.Approved, 3111, 31, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("\r\n                                                                                ", 3142, "&ViewName=AllHiringOrderUserToAdmin", 3224, 117, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    </li>\r\n                                                    <li>\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "00797a6c4b21cdc29b6daff56947710d50d6d58414853", async() => {
                WriteLiteral("\r\n                                                            رفض\r\n                                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 7, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3573, "~/HiringOrder/EvaluationApplicants?UserId=", 3573, 42, true);
#nullable restore
#line 60 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
AddHtmlAttributeValue("", 3615, Order.UserId, 3615, 13, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("\r\n                                                                                ", 3628, "&HiringOrdId=", 3710, 95, true);
#nullable restore
#line 61 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
AddHtmlAttributeValue("", 3723, Order.HiringOrderId, 3723, 20, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("\r\n                                                                                ", 3743, "&status=", 3825, 90, true);
#nullable restore
#line 62 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
AddHtmlAttributeValue("", 3833, StatusHiringOrderEnum.Rejected, 3833, 31, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("\r\n                                                                                ", 3864, "&ViewName=AllHiringOrderUserToAdmin", 3946, 117, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    </li>\r\n");
#nullable restore
#line 67 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
                                                }
                                                else if (Order.StatusType == StatusHiringOrderEnum.Approved)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <li>\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "00797a6c4b21cdc29b6daff56947710d50d6d58418321", async() => {
                WriteLiteral("\r\n                                                            رفض\r\n                                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 7, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4506, "~/HiringOrder/EvaluationApplicants?UserId=", 4506, 42, true);
#nullable restore
#line 71 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
AddHtmlAttributeValue("", 4548, Order.UserId, 4548, 13, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("\r\n                                                                                ", 4561, "&HiringOrdId=", 4643, 95, true);
#nullable restore
#line 72 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
AddHtmlAttributeValue("", 4656, Order.HiringOrderId, 4656, 20, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("\r\n                                                                                ", 4676, "&status=", 4758, 90, true);
#nullable restore
#line 73 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
AddHtmlAttributeValue("", 4766, StatusHiringOrderEnum.Rejected, 4766, 31, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("\r\n                                                                                ", 4797, "&ViewName=AllHiringOrderUserToAdmin", 4879, 117, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    </li>\r\n");
#nullable restore
#line 78 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
                                                }
                                                else if (Order.StatusType == StatusHiringOrderEnum.Rejected)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <li>\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "00797a6c4b21cdc29b6daff56947710d50d6d58421789", async() => {
                WriteLiteral("\r\n                                                            قبول\r\n                                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 7, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5439, "~/HiringOrder/EvaluationApplicants?UserId=", 5439, 42, true);
#nullable restore
#line 82 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
AddHtmlAttributeValue("", 5481, Order.UserId, 5481, 13, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("\r\n                                                                                ", 5494, "&HiringOrdId=", 5576, 95, true);
#nullable restore
#line 83 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
AddHtmlAttributeValue("", 5589, Order.HiringOrderId, 5589, 20, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("\r\n                                                                                ", 5609, "&status=", 5691, 90, true);
#nullable restore
#line 84 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
AddHtmlAttributeValue("", 5699, StatusHiringOrderEnum.Approved, 5699, 31, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("\r\n                                                                                ", 5730, "&ViewName=AllHiringOrderUserToAdmin", 5812, 117, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    </li>\r\n");
#nullable restore
#line 89 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                <li>\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "00797a6c4b21cdc29b6daff56947710d50d6d58425093", async() => {
                WriteLiteral("حذف");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 6206, "~/HiringOrder/DeleteHiringOrderApplicant?UserId=", 6206, 48, true);
#nullable restore
#line 92 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
AddHtmlAttributeValue("", 6254, Order.UserId, 6254, 13, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 6267, "&OrderId=", 6267, 9, true);
#nullable restore
#line 92 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
AddHtmlAttributeValue("", 6276, Order.HiringOrderId, 6276, 20, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                </li>\r\n                                            </ul>\r\n                                        </div>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 98 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n");
#nullable restore
#line 102 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 102 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
             
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"alert alert-info mt-3\">عزيزي لا يوجد أي متقدمين إلى الآن!</div>\r\n");
#nullable restore
#line 107 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\HiringOrder\AllHiringOrderUserToAdmin.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<GroupHiringUserToAdmin>> Html { get; private set; }
    }
}
#pragma warning restore 1591
