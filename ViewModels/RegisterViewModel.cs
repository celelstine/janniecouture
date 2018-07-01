using System;
using System.ComponentModel.DataAnnotations;
namespace jannieCouture.ViewModels
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
        }
		[Required]
		public string Email { get; set; }

        [Required]
        public string UserName { get; set; }
		[Required]
		[StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
		public string Password { get; set; }

        public string role { get; set; }
    }
}
