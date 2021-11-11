using AutoMapper;
using Hiring.Service.Helpers;
using Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Data;
using HiringWeb.Core.DTO;
using HiringWeb.Core.Enums;
using HiringWeb.Core.ViewModels;
using HiringWeb.DataBase.Models;
using HiringWeb.Services.FileOperations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Services.UserOperations
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<UserApplication> _userManage;
        private readonly RoleManager<IdentityRole> _roleManage;
        private readonly IMapper _Mapper;
        private readonly IFileServices _FileServices;
        public UserServices(ApplicationDbContext db,
                            UserManager<UserApplication> userManage,
                            RoleManager<IdentityRole> roleManage,
                            IMapper Mapper, IFileServices FileServices)
        {
            _db = db;
            _userManage = userManage;
            _Mapper = Mapper;
            _roleManage = roleManage;
            _FileServices = FileServices;
        }

        public async Task<UserPaginationIndex> Index(int PageNum, string SearchWord, int SelectSize)
        {
            // Pagination
            var PageSize = (double) SelectSize;// Number Element In Single Page
            if (SelectSize == 0 )
            {
                PageSize = 5.0;
            }
             
            var NumberPage = Math.Ceiling(await _db.Users.Where(a => !a.IsDelete &&
                                                   (a.Email.Contains(SearchWord) ||
                                                    a.FullName.Contains(SearchWord) ||
                                                    a.PhoneNumber.Contains(SearchWord) ||
                                                    string.IsNullOrEmpty(SearchWord)
                                                    )).CountAsync() / PageSize); // Number Pages
            if (PageNum < 1 || PageNum > NumberPage)
            {
                PageNum = 1;
            }
            var SkipRow = (int)((PageNum - 1) * PageSize);

            var Users = await _db.Users.Where(a => !a.IsDelete &&
                                                   ( a.Email.Contains(SearchWord) ||
                                                    a.FullName.Contains(SearchWord) ||
                                                    a.PhoneNumber.Contains(SearchWord) ||
                                                    string.IsNullOrEmpty(SearchWord)
                                                    ))
            .Skip(SkipRow).Take((int)PageSize).Select(user =>
            new UserIndexViewModel()
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ProfileImgUser = user.ProfileImgUser,
                AllRoles = user.TypeUser
            }).ToListAsync();

            return new UserPaginationIndex
            {
                NumberPage = (int)NumberPage,
                DisplayUser = Users,
                SentPageNum = PageNum
            };
        }

        public async Task<ErrorUserAddPostViewModel> AddGet()
        {
            var Roles = await _roleManage.Roles.ToListAsync();
            var SentModel = new ErrorUserAddPostViewModel
            {
                UserCreateDto = new UserCreateDto
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

        public async Task<ErrorUserAddPostViewModel> AddPost(UserCreateDto AddUser, string userId)
        {
            if(AddUser.AllRoles == null)
            {
                AddUser.AllRoles = new List<RoleChooseViewModel>();
                var item = new RoleChooseViewModel()
                {
                    Id = "34f3dcf7-7d9f-4e06-a31a-f54175c8e96a",
                    Name = "Applicant",
                    IsSelected = true
                };
                AddUser.AllRoles.Add(item);
            }
            var FoundEmail = await _userManage.FindByEmailAsync(AddUser.Email);
            if (FoundEmail != null)
            {
                var model = new ErrorUserAddPostViewModel
                {
                    UserCreateDto = AddUser,
                    ResultError = "عزيزي هذا البريد الإلكتروني مستخدم بالفعل !",
                    IsFalid = false
                };
                return model;
            }
            if (!AddUser.AllRoles.Any(a => a.IsSelected == true))
            {
                var model = new ErrorUserAddPostViewModel
                {
                    UserCreateDto = AddUser,
                    ResultError = "عزيزي من فضلك إختر صلاحية أو أكثر!",
                    IsFalid = false
                };
                return model;
            }
                var FileName = await _FileServices.SaveFile(AddUser.Cv, "AllFiles");

            var user = new UserApplication
            {
                UserName = AddUser.Email,
                FullName = AddUser.FullName,
                Email = AddUser.Email,
                TypeUser = string.Join("", AddUser.AllRoles.Where(a => a.IsSelected).Select(x => x.Name)),
                ProfileImgUser = AddUser.ProfileImgUser,
                Cv = FileName,
                PhoneNumber = AddUser.PhoneNumber,
                EmailConfirmed = true,
                CreateAt = DateTime.Now,
                CreateBy = userId,
                NumOrgnization = AddUser.NumOrgnization
            };

            var result = await _userManage.CreateAsync(user, AddUser.Password);
            if (result.Succeeded)
            {
                //Add Roles To New user
                var LsitRoleNname = AddUser.AllRoles.Where(a => a.IsSelected).Select(x => x.Name);
                await _userManage.AddToRolesAsync(user, LsitRoleNname);
                var model = new ErrorUserAddPostViewModel
                {
                    IsFalid = true,
                    UserId = user.Id
                };
                //Start Store Notification In Table NotificationDbEntity IN DB (Evaluation Applicant)
                var AdminId = await _db.Users.SingleOrDefaultAsync(a => a.FullName == "Admin System");

                var NotificationgData = new NotificationsDbEntity()
                {
                    UserSubjectId = user.Id, // Id To New User
                    UserObjectId = AdminId.Id, // Id To Admin
                    NotificationTime = DateTime.Now,
                    NotificationType = NotificationTypeEnum.NewUser
                };
                await _db.NotificationsDbEntity.AddAsync(NotificationgData);
                await _db.SaveChangesAsync();
                //End

                return model;
            }
            else
            {
                //var ResError = string.Empty;
                //foreach (var error in result.Errors)
                //{
                //    ResError = error.Description.ToString(new CultureInfo("ar"));
                //}
                var model = new ErrorUserAddPostViewModel
                {
                    UserCreateDto = AddUser,
                    ResultError = result.Errors.ToString(),
                    IsFalid = false
                };
                return model;
            }
        }

        public async Task<ErrorUserAddPostViewModel> EditGet(string Id)
        {
            var GetUser = await _userManage.FindByIdAsync(Id);
            if (GetUser == null)
            {
                return new ErrorUserAddPostViewModel
                {
                    IsFalid = false
                };
            }
            var AllRoles = await _roleManage.Roles.ToListAsync();

            var SetModle = new UserCreateDto
            {
                Id = GetUser.Id,
                FullName = GetUser.FullName,
                Email = GetUser.Email,
                PhoneNumber = GetUser.PhoneNumber,
                ProfileImgUser = GetUser.ProfileImgUser,
                NumOrgnization = GetUser.NumOrgnization,
                AllRoles = AllRoles.Select(role => new RoleChooseViewModel
                {
                    Id = role.Id,
                    Name = role.Name,
                    IsSelected = _userManage.IsInRoleAsync(GetUser, role.Name).Result
                }).ToList()
            };

            return new ErrorUserAddPostViewModel
            {
                IsFalid = true,
                UserCreateDto = SetModle
            };
        }

        public async Task<ErrorUserAddPostViewModel> EditPost(UserCreateDto RoleEdit, string userId)
        {
            var statusmodel = new ErrorUserAddPostViewModel();
            byte[] UserImage = null;
            string Cv = string.Empty;
            var FoundEmail = await _userManage.FindByEmailAsync(RoleEdit.Email);
            if (FoundEmail != null && FoundEmail.Id != RoleEdit.Id)
            {
                statusmodel.UserCreateDto = RoleEdit;
                statusmodel.ResultError = "عزيزي هذا البريد الإلكتروني مستخدم بالفعل !";
                statusmodel.IsFalid = false;
                return statusmodel;
            }

            if (!RoleEdit.AllRoles.Any(a => a.IsSelected == true))
            {
                statusmodel.UserCreateDto = RoleEdit;
                statusmodel.ResultError = "عزيزي من فضلك إختر صلاحية أو أكثر!";
                statusmodel.IsFalid = false;
                return statusmodel;
            }
            // Return User Will Be Updating
            var GetUser = await _userManage.FindByIdAsync(RoleEdit.Id);

            // Edit ProfileImgUser And Check IF User Sent New ProfileImgUser Or Not
            if (RoleEdit.ProfileImgUser == null)
            {
                UserImage = GetUser.ProfileImgUser;
            }
            else
            {
                UserImage = RoleEdit.ProfileImgUser;
            }

            // Edit Cv And Check IF User Sent New CV Or Not
            if(RoleEdit.Cv != null && RoleEdit.Cv.Length > 0)
            {
                _FileServices.DeleteFile(GetUser.Cv);
                var FileName = await _FileServices.SaveFile(RoleEdit.Cv, "AllFiles");
                Cv = FileName;
            }
            else
            {
                Cv = GetUser.Cv;
            }
            GetUser.FullName = RoleEdit.FullName;
            GetUser.TypeUser = string.Join("", RoleEdit.AllRoles.Where(a => a.IsSelected).Select(x => x.Name));
            GetUser.Email = RoleEdit.Email;
            GetUser.UserName = RoleEdit.Email;
            GetUser.Cv = Cv;
            GetUser.PhoneNumber = RoleEdit.PhoneNumber;
            GetUser.ProfileImgUser = UserImage;
            GetUser.UpdateAt = DateTime.Now;
            GetUser.UpdateBy = userId;
            await _userManage.UpdateAsync(GetUser);

            //Edit Roles To Admin
            var UserWithRoles = await _userManage.GetRolesAsync(GetUser);
            foreach (var item in RoleEdit.AllRoles)
            {
                if (UserWithRoles.Any(a => a == item.Name) && !item.IsSelected)
                {
                    await _userManage.RemoveFromRoleAsync(GetUser, item.Name);
                }

                if (!UserWithRoles.Any(a => a == item.Name) && item.IsSelected)
                {
                    await _userManage.AddToRoleAsync(GetUser, item.Name);
                }
            }

            statusmodel.IsFalid = true;
            return statusmodel;

        }

        public async Task<ErrorUser> Delete(string Id)
        {
            var ModelStatus = new ErrorUser();
            var GetUser = await _userManage.FindByIdAsync(Id);
            if (GetUser == null || GetUser.IsDelete)
            {
                ModelStatus.IsValid = false;
                return ModelStatus;
            }
            GetUser.IsDelete = true;
            await _userManage.UpdateAsync(GetUser);
            ModelStatus.IsValid = true;
            return ModelStatus;
        }

        public async Task<UserApplication> ReturnUser(string Id)
        {
            var RessearchUser = await _db.Users.Where(a => !a.IsDelete).SingleOrDefaultAsync(x => x.Id == Id);
            return RessearchUser;
        }
        public UserApplication ReturnUserByUsreNmae(string UserName)
        {
            var RessearchUser =  _db.Users.SingleOrDefault(x => x.UserName == UserName && !x.IsDelete);
            return RessearchUser;
        }

        public async Task<byte[]> ToExcel()
        {
            var users = _db.Users.Where(x => !x.IsDelete).ToList();

            return ExcelHelpers.ToExcel(new Dictionary<string, ExcelColumn>
            {
                {"إسم المستخدم", new ExcelColumn("إسم المستخدم", 0)},
                {"البريد الإلكتروني", new ExcelColumn("البريد الإلكتروني", 1)},
                {"رقم الجوال", new ExcelColumn("رقم الجوال", 2)},
                {"الصلاحيات", new ExcelColumn("الصلاحيات", 3)}
            }, new List<ExcelRow>(users.Select(e => new ExcelRow
            {
                Values = new Dictionary<string, string>
                {
                    {"إسم المستخدم", e.FullName},
                    {"البريد الإلكتروني", e.Email},
                    {"رقم الجوال", e.PhoneNumber},
                    {"الصلاحيات", string.Join(" , ", (List<string>)_userManage.GetRolesAsync(e).Result)}
                }
            })));
        }

    }
}
