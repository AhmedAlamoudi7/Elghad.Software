using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.ViewModels
{
    public class GenericError <NameClass>
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
        public NameClass ClassData { get; set; }
    }
}
