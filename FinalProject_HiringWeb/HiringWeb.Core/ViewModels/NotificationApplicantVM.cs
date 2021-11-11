using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Core.ViewModels
{
    public class NotificationApplicantVM
    {
        public string ApplicationStatus { get; set; }
        public string JobName { get; set; }
        public DateTime progressTime { get; set; }
        public string ApplicantId { get; set; }
        public int JobId { get; set; }
    }
}
