using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.DataBase.Models
{
    public class orgnization : BaseEntity
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public String WorkNature { get; set; }
        public String Address { get; set; }
        public String UserId { get; set; }
        public UserApplication User { get; set; }
        public List<HiringOrder> AllHiringOrder { get; set; }

    }
}
