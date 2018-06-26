using System;
using System.ComponentModel.DataAnnotations;

namespace jannieCouture.ViewModels
{
    public class ForgotPasswordViewModel
    {
        public ForgotPasswordViewModel()
        {
        }
		[Required]
		public string Email { get; set; }
    }
}
