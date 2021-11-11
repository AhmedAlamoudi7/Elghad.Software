using HiringWeb.Core.DTO;
using HiringWeb.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Services.RoleOperations
{
    public interface IRoleServices
    {
        Task<List<RoleIndexViewModel>> Index();
        Task Add(RoleAddDto RoleAdd);
        Task<RoleEditDto> EditGet(string Id);
        Task EditPost(RoleEditDto RoleEdit);
        Task Delete(string Id);
    }
}
