using HiringWeb.DataBase.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserApplication>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<HiringOrderuser>().HasKey(a => new { a.UserId, a.HiringOrderId });
        }

        public DbSet<orgnization> orgnization { get; set; }
        public DbSet<HiringOrder> HiringOrder { get; set; }
        public DbSet<HiringOrderAttachment> HiringOrderAttachment { get; set; }
        public DbSet<HiringOrderuser> HiringOrderuser { get; set; }
        public DbSet<NotificationsDbEntity> NotificationsDbEntity { get; set; }
    }
}
