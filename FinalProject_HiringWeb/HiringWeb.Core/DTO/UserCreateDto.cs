using HiringWeb.Core.Enums;
using HiringWeb.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.DTO
{
    public class UserCreateDto
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "إسم المستخدم")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [EmailAddress(ErrorMessage = "بريد إلكتروني غير صالح!")]
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }

        [Display(Name = "الصورة الذاتية")]
        public byte[] ProfileImgUser { get; set; }

        [Display(Name = "مرفق السيرة الذاتية")]
        public IFormFile Cv { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [RegularExpression(@"(\+?( |-|\.)?\d{1,2}( |-|\.)?)?(\(?\d{3}\)?|\d{3})( |-|\.)?(\d{3}( |-|\.)?\d{4})",
         ErrorMessage = "رقم الجوال غير صالح!")]
        [Display(Name = "رقم الجوال")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "كلمة السر")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "الحد الأدنى 6 حروف ويجب أن يحتوي على حروف وأرقام ورموز")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تأكيد كلمة السر")]
        [Compare("Password", ErrorMessage = "كلمة السر وتأكيد كلمة السر غير متطابقتين!")]
        public string ConfirmPassword { get; set; }

        public int? NumOrgnization { get; set; }

        public List<RoleChooseViewModel> AllRoles { get; set; }
    }
}
