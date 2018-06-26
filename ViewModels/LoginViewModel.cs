using System;
using System.ComponentModel.DataAnnotations;
namespace jannieCouture.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
        }
		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }
    }
}
