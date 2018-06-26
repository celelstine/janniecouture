using System;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace jannieCouture.Services
{
    public interface IEmailSender
    {
        void SendEmailAsync(string email, string subject, string message);
        void Execute(string email, string subject, string message);
    }

}
