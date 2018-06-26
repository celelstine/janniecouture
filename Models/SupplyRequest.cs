using System;
using System.ComponentModel;

namespace jannieCouture.Models
{
    public class SupplyRequest
    {
        public SupplyRequest()
        {
        }

        public int SupplyRequestId { get; set; }
        public Material Material { get; set; }
        public double Quantity { get; set; }
        public SupplyRequestStatus SupplyRequestStatus { get; set; }
		[DefaultValue(typeof(DateTime), "")]
		public DateTime DateCreated { get; set; }
        public DateTime? DateFullfilled { get; set; }
    }
}
