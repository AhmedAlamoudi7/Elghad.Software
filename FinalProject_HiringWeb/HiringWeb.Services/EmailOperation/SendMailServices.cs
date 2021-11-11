using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HiringWeb.Services.EmailOperation
{
    public class SendMailServices : ISendMailServices
    {
        public async Task<bool> SendMail(string To, string Subject, string Body)
        {
            // Content Message
            var Message = new MailMessage();
            Message.From = new MailAddress("projecthiringweb@gmail.com", "HiringWeb");
            Message.Subject = Subject;
            Message.Body = Body;
            Message.To.Add(new MailAddress(To));
            Message.IsBodyHtml = true;

            // Credentails (Authentication Project With MY Email)
            var EamilClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true, // Security Layer To Send Mail
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("projecthiringweb@gmail.com", "a2403284")
            };

            await EamilClient.SendMailAsync(Message);
            return true;

        }
    }
}
