using HiringWeb.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.ViewModels
{
   public class ErrorUserAddPostViewModel
    {
        public UserCreateDto UserCreateDto { get; set; }
        public string ResultError { get; set; }
        public string Key { get; set; }
        public string UserId { get; set; }
        public bool IsFalid { get; set; }
    }
}
