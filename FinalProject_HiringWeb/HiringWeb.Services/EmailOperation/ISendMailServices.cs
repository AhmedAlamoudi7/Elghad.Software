using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Services.EmailOperation
{
    public interface ISendMailServices
    {
        Task<bool> SendMail(string To, string Subject, string Body);
    }
}
