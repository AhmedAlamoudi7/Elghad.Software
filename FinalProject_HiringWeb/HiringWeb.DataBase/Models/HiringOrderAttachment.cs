using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.DataBase.Models
{
   public class HiringOrderAttachment
    {
        public int Id { get; set; }
        public string AttachmentUrl { get; set; }
        public int HiringOrderId { get; set; }
        public HiringOrder HiringOrder { get; set; }
    }
}
