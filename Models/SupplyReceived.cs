using System;
using System.ComponentModel;

namespace jannieCouture.Models
{
    public class SupplyReceived
    {
        public SupplyReceived()
        {
        }

        public int SupplyReceivedId { get; set; }
        public Supply Supply { get; set; }
        public double Quantity { get; set; }
		[DefaultValue(typeof(DateTime), "")]
		public DateTime DateReceived { get; set; }

    }
}
