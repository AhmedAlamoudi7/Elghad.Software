using HiringWeb.Core.DTO;
using HiringWeb.Core.ViewModels;
using HiringWeb.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Services.OrgnizationOperations
{
    public interface IOrgnizationServices
    {
        Task<OrgnizePaginationIndex> Index(int PageNum, string SearchWord, int SelectSize);
        Task<ErrorOrgnizeAdd> AddGet();
        Task<ErrorOrgnizeAdd> Add(OrgnizationAddDto AddOrg, string UserId);
        Task<ErrorOrgnizeEdit> EditGet(int Id);
        Task<ErrorOrgnizeEdit> EditPost(OrgnizationEditDto OrgEdit, string userId);
        Task<bool> Delete(int Id);
        Task<orgnization> ReturnOrgnization(int Id);
    }
}
