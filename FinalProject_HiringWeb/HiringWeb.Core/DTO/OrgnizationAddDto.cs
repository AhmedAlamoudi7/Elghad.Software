using HiringWeb.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.DTO
{
    public class OrgnizationAddDto
    {
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "إسم الشركة")]
        public string Name { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [EmailAddress(ErrorMessage = "بريد إلكتروني غير صالح!")]
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [RegularExpression(@"(\+?( |-|\.)?\d{1,2}( |-|\.)?)?(\(?\d{3}\)?|\d{3})( |-|\.)?(\d{3}( |-|\.)?\d{4})",
         ErrorMessage = "رقم الجوال غير صالح!")]
        [Display(Name = "رقم الجوال")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "إسم مدير الشركة")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "طبيعة عمل الشركة")]
        public string WorkNature { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "عنوان الشركة")]
        public string Address { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "الحد الأدنى 6 حروف ويجب أن يحتوي على حروف وأرقام ورموز")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "كلمة السر وتأكيد كلمة السر غير متطابقتين!")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "أدخل صورة الشركة")]
        public byte[] ProfileImgUser { get; set; }

        public List<RoleChooseViewModel> AllRoles { get; set; }

        public int? NumOrgnization { get; set; }


    }
}
