using AutoMapper;
using Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Data;
using HiringWeb.Core.DTO;
using HiringWeb.Core.ViewModels;
using HiringWeb.DataBase.Models;
using HiringWeb.Services.UserOperations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Services.OrgnizationOperations
{
    public class OrgnizationService : IOrgnizationServices
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _Mapper;
        private readonly IUserServices _IUserServices;
        private readonly RoleManager<IdentityRole> _roleManage;
        private readonly UserManager<UserApplication> _userManage;


        public OrgnizationService(ApplicationDbContext db,
                                  IMapper Mapper,
                                  IUserServices IUserServices,
                                  RoleManager<IdentityRole> roleManage,
                                  UserManager<UserApplication> userManage)
        {
            _db = db;
            _Mapper = Mapper;
            _IUserServices = IUserServices;
            _roleManage = roleManage;
            _userManage = userManage;
        }

        public async Task<OrgnizePaginationIndex> Index(int PageNum, string SearchWord, int SelectSize)
        {
            // Pagination
            var PageSize = (double)SelectSize;// Number Element In Single Page
            if (SelectSize == 0)
            {
                PageSize = 5.0;
            }

            var NumberPage = Math.Ceiling((_db.orgnization.Include(a => a.User).Where(a => !a.IsDelete &&
                                                   (a.Email.Contains(SearchWord) ||
                                                    a.User.FullName.Contains(SearchWord) ||
                                                    a.PhoneNumber.Contains(SearchWord) ||
                                                    a.Name.Contains(SearchWord) ||
                                                    a.WorkNature.Contains(SearchWord) ||
                                                    a.Address.Contains(SearchWord) ||
                                                    string.IsNullOrEmpty(SearchWord)
                                                    )).Count() / PageSize)); // Number Pages
            if (PageNum < 1 || PageNum > NumberPage)
            {
                PageNum = 1;
            }
            var SkipRow = (int)((PageNum - 1) * PageSize);

            var AllOrg = await _db.orgnization.Include(a => a.User)
                             .Where(a => !a.IsDelete &&
                                                   (a.Email.Contains(SearchWord) ||
                                                    a.Name.Contains(SearchWord) ||
                                                    a.User.FullName.Contains(SearchWord) ||
                                                    a.PhoneNumber.Contains(SearchWord) ||
                                                    a.WorkNature.Contains(SearchWord) ||
                                                    a.Address.Contains(SearchWord) ||
                                                    string.IsNullOrEmpty(SearchWord)))
                             .Skip(SkipRow).Take((int)PageSize)
                             .Select(Org => new OrgnizationIndexViewModel
                             {
                                 Id = Org.Id,
                                 Name = Org.Name,
                                 Email = Org.Email,
                                 PhoneNumber = Org.PhoneNumber,
                                 Address = Org.Address,
                                 WorkNature = Org.WorkNature,
                                 FullName = Org.User.FullName
                             }).ToListAsync();
            return new OrgnizePaginationIndex
            {
                NumberPage = (int)NumberPage,
                DisplayOrg = AllOrg,
                SentPageNum = PageNum
            };
        }

        public async Task<ErrorOrgnizeAdd> AddGet()
        {
            var Roles = await _roleManage.Roles.ToListAsync();
            var SentModel = new ErrorOrgnizeAdd
            {
                OrgnizationAddDto = new OrgnizationAddDto
                {
                    AllRoles = Roles.Select(role => new RoleChooseViewModel
                    {
                        Id = role.Id,
                        Name = role.Name,
                        IsSelected = false
                    }).ToList()
                }
            };
            return SentModel;
        }
        public async Task<ErrorOrgnizeAdd> Add(OrgnizationAddDto AddOrg, string userId)
        {

            var FoundEmail = await _db.orgnization.
                        SingleOrDefaultAsync(a => a.Email == AddOrg.Email);
            if (FoundEmail != null)
            {
                var model = new ErrorOrgnizeAdd
                {
                    OrgnizationAddDto = AddOrg,
                    ResultError = "عزيزي هذا البريد الإلكتروني مستخدم! بالفعل",
                    IsFalid = false,
                };
                return model;
            }

            // Convert From (OrgnizationAddDto) To (Orgnization)
            var Org = _Mapper.Map<orgnization>(AddOrg);
            Org.CreateBy = userId;
            //Add New Orgnization To DB
            await _db.orgnization.AddAsync(Org);



            // Convert From (OrgnizationAddDto) To (UserCreateDto)
            var CreateuserToOrg = _Mapper.Map<UserCreateDto>(AddOrg);
            //Add New User To DB Using InterfaceUserServices To Become Admin On Orgnization
            var UserCreated = await _IUserServices.AddPost(CreateuserToOrg, userId);
            if (!UserCreated.IsFalid)
            {
                return new ErrorOrgnizeAdd
                {
                    IsFalid = false,
                    OrgnizationAddDto = AddOrg,
                    ResultError = UserCreated.ResultError
                };
            }

            await _db.SaveChangesAsync();

            //Update UserId To table Orgnization
            Org.UserId = UserCreated.UserId;
            _db.orgnization.Update(Org);
            _db.SaveChanges();

            //Update NumOrgnization To table User
            var returnuser = await _IUserServices.ReturnUser(UserCreated.UserId);
            returnuser.NumOrgnization = Org.Id;
            _db.Users.Update(returnuser);
            _db.SaveChanges();

            return new ErrorOrgnizeAdd { IsFalid = true };
        }

        public async Task<ErrorOrgnizeEdit> EditGet(int Id)
        {
            var GetOrg = await _db.orgnization.Include(a => a.User).SingleOrDefaultAsync(a => a.Id == Id);
            if (GetOrg == null)
            {
                return new ErrorOrgnizeEdit
                {
                    IsFalid = false
                };
            }
            var AllRoles = await _roleManage.Roles.ToListAsync();

            var SetModle = new OrgnizationEditDto
            {
                Id = GetOrg.Id,
                Name = GetOrg.Name,
                Email = GetOrg.Email,
                PhoneNumber = GetOrg.PhoneNumber,
                WorkNature = GetOrg.WorkNature,
                Address = GetOrg.Address,
                FullName = GetOrg.User.FullName,
                AllRoles = AllRoles.Select(role => new RoleChooseViewModel
                {
                    Id = role.Id,
                    Name = role.Name,
                    IsSelected = _userManage.IsInRoleAsync(GetOrg.User, role.Name).Result
                }).ToList()
            };

            return new ErrorOrgnizeEdit
            {
                IsFalid = true,
                OrgnizationEditDto = SetModle
            };

        }

        public async Task<ErrorOrgnizeEdit> EditPost(OrgnizationEditDto OrgEdit, string userId)
        {
            string Name = OrgEdit.Name;
            string Address = OrgEdit.Address;
            string WorkNature = OrgEdit.WorkNature;


            var FoundEmail = await _db.orgnization.
                        SingleOrDefaultAsync(a => a.Email == OrgEdit.Email);
            if (FoundEmail != null && FoundEmail.Id != OrgEdit.Id)
            {
                var model = new ErrorOrgnizeEdit
                {
                    OrgnizationEditDto = OrgEdit,
                    ResultError = "عزيزي هذا البريد الإلكتروني مستخدم بالفعل !",
                    IsFalid = false
                };
                return model;
            }
            var EditOrgnization = _db.orgnization.Find(OrgEdit.Id);
            if (OrgEdit.Name == null)
            {
                Name = EditOrgnization.Name;
            }
            if (OrgEdit.Address == null)
            {
                Address = EditOrgnization.Address;
            }
            if (OrgEdit.WorkNature == null)
            {
                WorkNature = EditOrgnization.WorkNature;
            }


            EditOrgnization.Name = Name;
            EditOrgnization.Email = OrgEdit.Email;
            EditOrgnization.PhoneNumber = OrgEdit.PhoneNumber;
            EditOrgnization.Address = Address;
            EditOrgnization.WorkNature = WorkNature;
            EditOrgnization.UpdateAt = DateTime.Now;
            EditOrgnization.UpdateBy = userId;

            _db.orgnization.Update(EditOrgnization);

            var SentUser = new UserCreateDto
            {
                Id = EditOrgnization.UserId,
                FullName = OrgEdit.FullName,
                Email = OrgEdit.Email,
                PhoneNumber = OrgEdit.PhoneNumber,
                ProfileImgUser = OrgEdit.ProfileImgUser,
                AllRoles = OrgEdit.AllRoles,
            };

            var ResEditDataUser = await _IUserServices.EditPost(SentUser, userId);

            if (!ResEditDataUser.IsFalid)
            {
                return new ErrorOrgnizeEdit
                {
                    IsFalid = false,
                    OrgnizationEditDto = OrgEdit,
                    ResultError = ResEditDataUser.ResultError
                };
            }
            _db.SaveChanges();
            return new ErrorOrgnizeEdit
            {
                IsFalid = true
            };
        }

        public async Task<bool> Delete(int Id)
        {
            var GetOrg = await _db.orgnization.FindAsync(Id);
            if (GetOrg == null || GetOrg.IsDelete)
            {
                return false;
            }
            // Delete Orgnization
            GetOrg.IsDelete = true;
            _db.orgnization.Update(GetOrg);
            _db.SaveChanges();

            // Get User Admin And Delete This User
            var GetUsre = await _db.Users.FindAsync(GetOrg.UserId);
            GetUsre.IsDelete = true;
            _db.Users.Update(GetUsre);
            _db.SaveChanges();
            return true;
        }

        public async Task<orgnization> ReturnOrgnization(int Id)
        {
            var RessearchOrg = await _db.orgnization.Include(a => a.User)
                                     .SingleOrDefaultAsync(a => !a.IsDelete &&  a.Id == Id);
            return RessearchOrg;
        }



    }
}
