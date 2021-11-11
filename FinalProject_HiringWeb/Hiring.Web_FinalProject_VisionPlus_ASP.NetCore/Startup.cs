using Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Data;
using HiringWeb.DataBase.Models;
using HiringWeb.Services.DashBoardOperations;
using HiringWeb.Services.EmailOperation;
using HiringWeb.Services.FileOperations;
using HiringWeb.Services.HiringOrderOperations;
using HiringWeb.Services.NotificationsOperations;
using HiringWeb.Services.OrgnizationOperations;
using HiringWeb.Services.RoleOperations;
using HiringWeb.Services.UserOperations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiring.Web_FinalProject_VisionPlus_ASP.NetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<UserApplication, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI().AddDefaultTokenProviders();//This Line To Go Screen Login When Not Authorize

            services.AddControllersWithViews();

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IRoleServices, RoleServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IOrgnizationServices, OrgnizationService>();
            services.AddScoped<IHiringOrderService, HiringOrderService>();
            services.AddScoped<ISendMailServices, SendMailServices>();
            services.AddScoped<IFileServices, FileServices>();
            services.AddScoped<IDashBoardServices, DashBoardServices>();
            services.AddScoped<INotificationServices, NotificationServices>();


            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=LandingPage}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
