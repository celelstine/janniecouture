using System;
using System.Collections.Generic;
namespace jannieCouture.Models
{
    public class RatedEntity
    {
        public RatedEntity()
        {
        }
		public int RatedEntityID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
        public List<CustomerFullfilment> CustomerFullfilments { get; set; } 
    }
}
