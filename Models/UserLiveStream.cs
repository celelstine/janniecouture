using System;
using System.ComponentModel;
namespace jannieCouture.Models
{
    public class UserLiveStream
    {
        public UserLiveStream()
        {
        }

        public int UserLiveStreamId { get; set; }
        public int? UserId { get; set; }
        public string email { get; set;  }
        public string link { get; set; }
		[DefaultValue(typeof(DateTime), "")]
        public DateTime DateCreated { get; set; }
        public string IPAddress { get; set;  }
    }
}
