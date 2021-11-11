using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.ViewModels
{
    public class OrgnizationIndexViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public String WorkNature { get; set; }
        public String Address { get; set; }
        public string FullName { get; set; }

    }
}
