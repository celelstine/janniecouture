using System;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace jannieCouture.Services
{
    public class EmailSender: IEmailSender
    {
        private readonly IConfiguration _configuration;
		public EmailSender(
            IOptions<AuthMessageSenderOptions> optionsAccessor,
			 IConfiguration configuration
        )
		{
			Options = optionsAccessor.Value;
            _configuration = configuration;
		}

		public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

		public void SendEmailAsync(string email, string subject, string message)
		{
			Execute(email, subject, message);
		}

		public void Execute(string email, string subject, string message)
		{
			var client = new SendGridClient(_configuration["SendGridKey"]);
			var msg = new SendGridMessage()
			{
				From = new EmailAddress(_configuration["ContactEmail"], "Jannie Couture"),
				Subject = subject,
				PlainTextContent = message,
				HtmlContent = message
			};
			msg.AddTo(new EmailAddress(email));
            var response = client.SendEmailAsync(msg).ConfigureAwait(false);
            Console.WriteLine("------------->" + email);
            Console.WriteLine("------------->" + message, "<--------------");
            Console.WriteLine("------------->" +  _configuration["SendGridKey"], "<--------------");
            Console.WriteLine("------------->" + response.ToString(), "<--------------");

		}
    }
}
