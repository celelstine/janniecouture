using System;
namespace jannieCouture.Services
{
    public class AuthMessageSenderOptions
    {
        public AuthMessageSenderOptions()
        {
        }
		public string SendGridUser { get; set; }
		public string SendGridKey { get; set; }
    }
}
