using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.DTO
{
    public class RoleEditDto
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "إسم الصلاحية")]
        public string Name { get; set; }
    }
}
