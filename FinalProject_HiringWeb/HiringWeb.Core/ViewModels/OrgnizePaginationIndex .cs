using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.ViewModels
{
   public class OrgnizePaginationIndex
    {
        public int NumberPage { get; set; }
        public int SentPageNum { get; set; }
        public List<OrgnizationIndexViewModel> DisplayOrg{ get; set; }
    }
}
