using HiringWeb.Core.DTO;
using HiringWeb.Core.ViewModels;
using HiringWeb.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Services.UserOperations
{
    public interface IUserServices
    {
        Task<UserPaginationIndex> Index(int PageNum, string SearchWord, int SelectSize);
        Task<ErrorUserAddPostViewModel> AddGet();
        Task<ErrorUserAddPostViewModel> AddPost(UserCreateDto AddUser, string UserId);
        Task<ErrorUserAddPostViewModel> EditGet(string Id);
        Task<ErrorUserAddPostViewModel> EditPost(UserCreateDto RoleEdit, string userId);
        Task<ErrorUser> Delete(string Id);
        Task<UserApplication> ReturnUser(string Id);
        UserApplication ReturnUserByUsreNmae(string UserName);
        Task<byte[]> ToExcel();
    }
}
