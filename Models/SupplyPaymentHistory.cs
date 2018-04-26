using System;
using System.ComponentModel;

namespace jannieCouture.Models
{
    public class SupplyPaymentHistory
    {
        public SupplyPaymentHistory()
        {
        }

		public int SupplyPaymentHistoryId { get; set; }
        public SupplyPayment SupplyPayment { get; set; }
		public double Amount { get; set; }
		public PaymentMethod PaymentMethod { get; set; }
		public int Userid { get; set; }
		[DefaultValue(typeof(DateTime), "")]
		public DateTime DateCreated { get; set; }
		public Currency Currency { get; set; }
	}
}
