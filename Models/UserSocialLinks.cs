using System;
namespace jannieCouture.Models
{
    public class UserSocialLink
    {
        public UserSocialLink()
        {
        }
        public int UserSocialLinkId { get; set; }
        public string SocialMediaBrand { get; set; }
        public string Username { get; set; }

    }
}
