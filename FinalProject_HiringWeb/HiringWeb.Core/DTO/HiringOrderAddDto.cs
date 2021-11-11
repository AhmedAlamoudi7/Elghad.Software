using HiringWeb.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.DTO
{
    public class HiringOrderAddDto
    {
        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        [Display(Name = "عنوان الطلب")]
        public String Title { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "الراتب الشهري")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "وصف الطلب")]
        public String Description { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "وقت إنتهاء الطلب")]
        public DateTime Deadline { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "إسم الشركة")]
        public int OrgnizationId { get; set; }

        [Display(Name = "المرفقات")]
        public List<IFormFile>  Attachments { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "صورة الوظيفة")]
        public IFormFile JobImg { get; set; }
    }
}
