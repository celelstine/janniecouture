using System;
using Microsoft.AspNetCore.Identity;
namespace jannieCouture.Models
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {
        }


		public UserCategory UserCategory { get; set; }
        public UserMeta UserMeta { get; set; }

    }
}
