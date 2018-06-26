using System;
namespace jannieCouture.Models
{
    public class UserMeta
    {
        public UserMeta()
        {
        }
        public int UserMetaId { get; set; }
        public string email { get; set; }
        public String Gender { get; set; }
        public String Religion { get; set; }
        public string ProfileImage { get; set; }
    }
}
