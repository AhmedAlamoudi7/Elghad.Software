using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.ModelaDB
{
    public class HiringOrderAllPropViewModel
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public double Salary { get; set; }
        public orgnizationViewModel Orgnization { get; set; }

    }
}
