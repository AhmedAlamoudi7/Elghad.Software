#pragma checksum "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\Home\DashBoardAdmin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53f4e5ae722d75f0d25db545994262dcfbba1771"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DashBoardAdmin), @"mvc.1.0.view", @"/Views/Home/DashBoardAdmin.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53f4e5ae722d75f0d25db545994262dcfbba1771", @"/Views/Home/DashBoardAdmin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8cfb432cd72c8602dead687194425aa001c82e0c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DashBoardAdmin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MainDataDashBoardViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\Home\DashBoardAdmin.cshtml"
   ViewData["Title"] = "Home Page"; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""card card-custom"">
    <div class=""card-header flex-wrap border-0 pt-6 pb-0"">
        <div class=""card-title"">
            <h2 class=""card-label"">
                <span class=""d-block pt-5 font-size-h2-lg"">???????? ?????????? ???????????????????? </span>
            </h2>
        </div>
    </div>
    
    <div class=""card-body"">
        <div class=""row"">

            <div class=""col-md-3 col-sm-6"" data-aos=""fade-left"">
                <div class=""alert alert-info"">
                    <h3>???????????? ?????? ????????????????????</h3>
                    <h4>");
#nullable restore
#line 20 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\Home\DashBoardAdmin.cshtml"
                   Write(Model.NumberUsers);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"col-md-3 col-sm-6\" data-aos=\"fade-left\">\r\n                <div class=\"alert alert-info\">\r\n                    <h3>???????????? ?????? ?????????? ??????????????</h3>\r\n                    <h4>");
#nullable restore
#line 27 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\Home\DashBoardAdmin.cshtml"
                   Write(Model.NumberHiringOrders);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"col-md-3 col-sm-6\" data-aos=\"fade-left\">\r\n                <div class=\"alert alert-info\">\r\n                    <h3>???????????? ?????? ??????????????????</h3>\r\n                    <h4>");
#nullable restore
#line 34 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\Home\DashBoardAdmin.cshtml"
                   Write(Model.NumberApplicants);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"col-md-3 col-sm-6\" data-aos=\"fade-left\">\r\n                <div class=\"alert alert-info\">\r\n                    <h3>???????????? ?????? ????????????????</h3>\r\n                    <h4>");
#nullable restore
#line 41 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\Home\DashBoardAdmin.cshtml"
                   Write(Model.NumberCompanys);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
                </div>
            </div>

        </div>

        <br />

        <div class=""row"">
            <div class=""col-lg-6 col-sm-12 mb-4"" data-aos=""fade-left"">
                <canvas id=""userTypeChart"" height=""40vh"" width=""80vw"">
                </canvas>
            </div>
            <div class=""col-lg-6 col-sm-12 mb-4"" data-aos=""fade-left"">
                <canvas id=""hiringOrderTypeChart"" height=""40vh"" width=""80vw"">
                </canvas>
            </div>
        </div>

        <hr />

        <div class=""row"">
            <div class=""col-lg-6 col-sm-12 mb-4"" data-aos=""fade-left"">
                <canvas id=""hiringOrderPublishByMonthChart"" height=""40vh"" width=""80vw"">
                </canvas>
            </div>
            <div class=""col-lg-6 col-sm-12 mb-4"" data-aos=""fade-left"">
                <canvas id=""hiringOrderApplyingByMonthChart"" height=""40vh"" width=""80vw"">
                </canvas>
            </div>
        </div>

    </div>
</div>
");
            WriteLiteral("\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""https://cdnjs.com/libraries/Chart.js""></script>

    <script>
         var userTypeChart = document.getElementById('userTypeChart');
         var hiringOrderTypeChart = document.getElementById('hiringOrderTypeChart');
         var hiringOrderPublishByMonthChart = document.getElementById('hiringOrderPublishByMonthChart');
         var hiringOrderApplyingByMonthChart = document.getElementById('hiringOrderApplyingByMonthChart');
         var userTypeData = [];
         var hiringOrderTypeData = [];
         var hiringOrderPublishByMonthData = [];
         var hiringOrderApplyingByMonthData= [];

          $.ajax({
              url: '");
#nullable restore
#line 91 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\Home\DashBoardAdmin.cshtml"
               Write(Url.Action("GetUserType", "Home"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
              contentType: ""application/json; charset=utf-8"",
              dataType: ""json"",
              Cache: false,
              success: function (Data) {
                  $.each(Data, function (index, value) {
                      userTypeData.push(Data[index])
                      //console.log(""Index"" +index);
                      //console.log(""Value"" + value);
                  });
             
                  var myChart1 = new Chart(userTypeChart, {
                      type: 'pie',
                      data: {
                          labels: ['??????????????', '?????????? ????????????????', '??????????????????'],
                          datasets: [{
                              label: '# of Votes',
                              data: userTypeData,
                              backgroundColor: [
                                  'rgb(255, 99, 132)',
                                  'rgb(54, 162, 235)',
                                  'rgb(255, 206, 86)'
                           ");
                WriteLiteral(@"   ]
                          }]
                      },
                      options: {
                          title: { // This Label Will Be Show With Labels In datasets
                              display: true,
                              text: '?????????? ????????????????????'
                          }
                      }
                  });

              }
          });

          $.ajax({
              url: '");
#nullable restore
#line 128 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\Home\DashBoardAdmin.cshtml"
               Write(Url.Action("GethiringOrderTypeChart", "Home"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
              contentType: ""application/json; charset=utf-8"",
              dataType: ""json"",
              Cache: false,
              success: function (Data) {
                  $(Data).each(function (index, value) {
                      hiringOrderTypeData.push(value);
                  });

                  var myChart2 = new Chart(hiringOrderTypeChart, {
                      type: 'pie',
                      data: {
                          labels: ['?????? ????????????????', '??????????', '??????????'],
                          datasets: [{
                              label: '# of Votes',
                              data: hiringOrderTypeData,
                              backgroundColor: [
                                  'rgb(255, 99, 132)',
                                  'rgb(54, 162, 235)',
                                  'rgb(255, 206, 86)'
                              ]
                          }]
                      },
                      options: {
                  ");
                WriteLiteral(@"        title: { // This Label Will Be Show
                              display: true,
                              text: '?????????? ?????????? ??????????????'
                          }
                      }
                  });

              }
          });

          $.ajax({
              url: '");
#nullable restore
#line 163 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\Home\DashBoardAdmin.cshtml"
               Write(Url.Action("GethiringOrderPublishByMonthChart", "Home"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
              contentType: ""application/json; charset=utf-8"",
              dataType: ""json"",
              Cache: false,
              success: function (Data) {
                  $(Data).each(function (index, value) {
                      hiringOrderPublishByMonthData.push(value);
                  });

                  var myChart3 = new Chart(hiringOrderPublishByMonthChart, {
                      type: 'bar',
                      data: {
                          labels: ['??????????', '????????????', '????????', '??????????', '????????', '??????????', '??????????', '??????????', '??????????', '????????????', '????????????', '????????????'],
                          datasets: [{
                              label: '?????? ??????????????',
                              data: hiringOrderPublishByMonthData,
                              backgroundColor: [
                                  'rgb(255, 99, 132)',
                                  'rgb(54, 162, 235)',
                                  'rgb(255, 206, 86)',
                                 ");
                WriteLiteral(@" 'rgb(255, 99, 142)',
                                  'rgb(54, 162, 235)',
                                  'rgb(255, 206, 86)',
                                  'rgb(255, 99, 132)',
                                  'rgb(54, 162, 235)',
                                  'rgb(255, 206, 86)',
                                  'rgb(255, 99, 132)',
                                  'rgb(54, 162, 235)',
                                  'rgb(255, 206, 86)'
                              ]
                          }]
                      },
                      options: {
                          legend: { display: false }, // To Hide Label In dataset
                          title: { // This Label Will Be Show
                              display: true,
                              text: '?????? ?????????????? ???????????????? ???? ???? ??????'
                          }
                      }
                  });
              }
          });

          $.ajax({
              url: '");
#nullable restore
#line 207 "E:\FinalProject_VisionPlus_HiringWeb\Hiring.Web_FinalProject_VisionPlus_ASP.NetCore\Views\Home\DashBoardAdmin.cshtml"
               Write(Url.Action("GethiringOrderApplyingByMonthChart", "Home"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
              contentType: ""application/json; charset=utf-8"",
              dataType: ""json"",
              Cache: false,
              success: function (Data) {
                  $(Data).each(function (index, value) {
                      hiringOrderApplyingByMonthData.push(value);
                  });

                  var myChart3 = new Chart(hiringOrderApplyingByMonthChart, {
                      type: 'bar',
                      data: {
                          labels: ['??????????', '????????????', '????????', '??????????', '????????', '??????????', '??????????', '??????????', '??????????', '????????????', '????????????', '????????????'],
                          datasets: [{
                              label: '?????? ??????????????????',
                              data: hiringOrderApplyingByMonthData,
                              backgroundColor: [
                                  'rgb(255, 99, 132)',
                                  'rgb(54, 162, 235)',
                                  'rgb(255, 206, 86)',
                            ");
                WriteLiteral(@"      'rgb(255, 99, 142)',
                                  'rgb(54, 162, 235)',
                                  'rgb(255, 206, 86)',
                                  'rgb(255, 99, 132)',
                                  'rgb(54, 162, 235)',
                                  'rgb(255, 206, 86)',
                                  'rgb(255, 99, 132)',
                                  'rgb(54, 162, 235)',
                                  'rgb(255, 206, 86)'
                              ]
                          }]
                      },
                      options: {
                          legend: { display: false }, // To Hide Label In dataset
                          title: { // This Label Will Be Show
                              display: true,
                              text: '?????? ?????????????????? ???? ???? ??????'
                          }
                      }
                  });
              }
          });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MainDataDashBoardViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
