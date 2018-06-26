using System;
using System.ComponentModel;
namespace jannieCouture.Models
{
    public class CustomerFullfilment
    {
        public CustomerFullfilment()
        {
        }
        public int CustomerFullfilmentId { get; set; }
        public int? UserId { get; set; }
        public string email { get; set; }
        public Rating Rating { get; set; }
		[DefaultValue(typeof(DateTime), "")]
		public DateTime DateCreated { get; set; }
        public string Note { get; set; }
        public RatedEntity RatedEntity { get; set; } 
    }
}
