#pragma checksum "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\Notifications\NotificateAdminNewUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92e7959912d98becfb38fd64fd64046c67468c28"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Notifications_NotificateAdminNewUser), @"mvc.1.0.view", @"/Views/Notifications/NotificateAdminNewUser.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92e7959912d98becfb38fd64fd64046c67468c28", @"/Views/Notifications/NotificateAdminNewUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8cfb432cd72c8602dead687194425aa001c82e0c", @"/Views/_ViewImports.cshtml")]
    public class Views_Notifications_NotificateAdminNewUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HiringWeb.Core.ModelaDB.UserApplicationViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color:black;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary mt-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\Notifications\NotificateAdminNewUser.cshtml"
  
    ViewData["Title"] = "تفاصيل المستخدم";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""card card-custom"">
    <div class=""card-header flex-wrap border-0 pt-6 pb-0"">
        <div class=""card-title"">
            <h2 class=""card-label"" data-aos=""fade-left"">
                <span class=""d-block pt-5 font-size-h2-lg"">تفاصيل المستخدم</span>
            </h2>
        </div>
    </div>
    <hr />
    <div class=""card-body"">
        <div class=""table-responsive"">
            <table class=""table table-bordered table-striped""
                   style="" border: 5px solid #788da3; text-align: center; background: #1f518fad;"">
                <thead style=""background: #a94442; color: #eee038f2; font-size: 27px;"">
                    <tr>
                        <td>العنوان</td>
                        <td>التفاصيل</td>
                    </tr>
                </thead>

                <tbody>
                    <tr data-aos=""fade-left"">
                        <td>اسم المستخدم</td>
                        <td>");
#nullable restore
#line 29 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\Notifications\NotificateAdminNewUser.cshtml"
                       Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr data-aos=\"fade-left\">\r\n                        <td>البريد الالكتروني</td>\r\n                        <td>");
#nullable restore
#line 33 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\Notifications\NotificateAdminNewUser.cshtml"
                       Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr data-aos=\"fade-left\">\r\n                        <td>رقم جوال</td>\r\n                        <td>");
#nullable restore
#line 37 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\Notifications\NotificateAdminNewUser.cshtml"
                       Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr data-aos=\"fade-left\">\r\n                        <td>السيرة الذاتية</td>\r\n                        <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "92e7959912d98becfb38fd64fd64046c67468c288723", async() => {
                WriteLiteral("إضغط لعرض CV");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1611, "~/AllFiles/", 1611, 11, true);
#nullable restore
#line 41 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\Notifications\NotificateAdminNewUser.cshtml"
AddHtmlAttributeValue("", 1622, Model.Cv, 1622, 9, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n        <div class=\"form-group col-md-12\" data-aos=\"fade-left\">\r\n            <div>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "92e7959912d98becfb38fd64fd64046c67468c2810666", async() => {
                WriteLiteral("الرجوع للمستخدمين");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HiringWeb.Core.ModelaDB.UserApplicationViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591