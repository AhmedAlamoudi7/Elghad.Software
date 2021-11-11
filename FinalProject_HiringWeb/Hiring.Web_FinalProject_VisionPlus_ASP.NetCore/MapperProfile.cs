using AutoMapper;
using HiringWeb.Core.DTO;
using HiringWeb.Core.ModelaDB;
using HiringWeb.Core.ViewModels;
using HiringWeb.DataBase.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiring.Web_FinalProject_VisionPlus_ASP.NetCore
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            
            CreateMap<UserApplication, UserIndexViewModel>();
            CreateMap<IdentityRole, RoleIndexViewModel>();
            CreateMap<RoleAddDto, IdentityRole>();
            CreateMap<IdentityRole, RoleEditDto>();
            CreateMap<OrgnizationAddDto, orgnization>();
            CreateMap<OrgnizationAddDto, UserCreateDto>();
            CreateMap<UserCreateDto, OrgnizationEditDto>();
            CreateMap<HiringOrder,HiringOrderIndexViewModel>();
            CreateMap<HiringOrderAddDto, HiringOrder>();
            CreateMap<HiringOrder, HiringOrderEditDto>();
            CreateMap<HiringOrderEditDto, HiringOrder>();
            CreateMap<HiringOrder, HiringOrderDetailsViewModel>();
            CreateMap<HiringOrderAttachment, HiringOrderAttachmentViewModel>();
            CreateMap<orgnization, orgnizationViewModel>();
            CreateMap<UserApplication, GetUsersApplyingOrderViewModel>();
            CreateMap<HiringOrderuser, HiringOrderUserViewModel>();
            CreateMap<UserApplication, UserApplicationViewModel>();
            CreateMap<HiringOrder, HiringOrderViewModel>();
            CreateMap<HiringOrderuser, GetApplyingOrdersToUserViewModel>();
            CreateMap<HiringOrder, HiringOrderUserAllDataViewModel>();
            CreateMap<HiringOrder, AllHiringOrdHomePageViewModel>();
            CreateMap<HiringOrderuser, NotificateDetailsApplicantViewModel>();
            CreateMap<HiringOrder, HiringOrderAllPropViewModel>();
            CreateMap<HiringOrderuser, NotificateDetailsOrgApplicantViewModel>();
        }
    }
}
