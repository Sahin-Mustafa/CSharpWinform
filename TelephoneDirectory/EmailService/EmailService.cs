
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneDirectory
{
    public class EmailService : IEmailService
    {
        public void SendEmail(EmailBody request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("yazilimDeneme0@gmail.com"));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Text) { Text= request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("yazilimDeneme0@gmail.com", "fzkmugsrkajkibun");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
