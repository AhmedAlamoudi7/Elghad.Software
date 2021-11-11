using HiringWeb.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.DTO
{
    public class OrgnizationEditDto
    {
        public int Id { get; set; }

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

        [Display(Name = "أدخل صورة الشركة")]
        public byte[] ProfileImgUser { get; set; }

        public int NumOrgnization { get; set; }

        public List<RoleChooseViewModel> AllRoles { get; set; }
    }
}
