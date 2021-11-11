using Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Data;
using HiringWeb.DataBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.DataBase
{
    public static class DBSeeder
    {
        public static IHost SeedDb(this IHost webHost)
        {
            using var scope = webHost.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                try
                {
                    context.Database.Migrate();
                }
                catch
                {
                    // ignore
                }

                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                roleManager.SeedRoles().Wait();

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserApplication>>();
                userManager.SeedAdmin().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return webHost;
        }

        public static async Task SeedRoles(this RoleManager<IdentityRole> roleManager)
        {

            if (await roleManager.Roles.AnyAsync()) return;
            var roleNames = new List<string>();
            roleNames.Add("Admin");
            roleNames.Add("OrgnisationAdmin");
            roleNames.Add("Applicant");

            foreach (var role in roleNames)
            {
                await roleManager.CreateAsync(new IdentityRole() {Name = role });
            }
        }

        public static async Task SeedAdmin(this UserManager<UserApplication> userManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var user = new UserApplication();
            user.UserName = "Admin@System.com";
            user.Email = "Admin@System.com";
            user.FullName = "Admin System";
            user.TypeUser = "Admin";
            user.CreateAt = DateTime.Now;
            user.EmailConfirmed = true;

            await userManager.CreateAsync(user, "Aa123##");

            await userManager.AddToRoleAsync(user, user.TypeUser);
        }



    }
}
