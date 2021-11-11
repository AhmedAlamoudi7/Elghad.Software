using AutoMapper;
using Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Data;
using HiringWeb.Core.DTO;
using HiringWeb.Core.ViewModels;
using HiringWeb.DataBase.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Services.RoleOperations
{
    public class RoleServices : IRoleServices
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<UserApplication> _userManager;
        private readonly RoleManager<IdentityRole> _rolerManager;
        private readonly IMapper _Mapper;
        public RoleServices(ApplicationDbContext db,
                                UserManager<UserApplication> userManager,
                                RoleManager<IdentityRole> rolerManager,
                                IMapper Mapper)
        {
            _db = db;
            _userManager = userManager;
            _rolerManager = rolerManager;
            _Mapper = Mapper;

        }

        public async Task<List<RoleIndexViewModel>> Index()
        {
            var Roles = await _db.Roles.ToListAsync();
            return _Mapper.Map<List<RoleIndexViewModel>>(Roles);
        }

        public async Task Add(RoleAddDto RoleAdd)
        {
            var role = _Mapper.Map<IdentityRole>(RoleAdd);
            await _rolerManager.CreateAsync(role);
        }

        public async Task<RoleEditDto> EditGet(string Id)
        {
            var role = await _rolerManager.FindByIdAsync(Id);
            return _Mapper.Map<RoleEditDto>(role);
        }

        public async Task EditPost(RoleEditDto RoleEdit)
        {
            var role = await _rolerManager.FindByIdAsync(RoleEdit.Id);
            role.Name = RoleEdit.Name;
            await _rolerManager.UpdateAsync(role);
        }

        public async Task Delete(string Id)
        {
            var role = await _rolerManager.FindByIdAsync(Id);
            await _rolerManager.DeleteAsync(role);
        }


    }
}
