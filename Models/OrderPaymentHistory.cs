using System;
using System.ComponentModel;
namespace jannieCouture.Models
{
    public class OrderPaymentHistory
    {
        public OrderPaymentHistory()
        {
        }

        public int OrderPaymentHistoryId { get; set; }
        public OrderPayment OrderPayment { get; set; }
        public double Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int Userid { get; set; }
        public int? OrderItemId { get; set; }
        public virtual OrderItem OrderItem { get; set; }
		[DefaultValue(typeof(DateTime), "")]
		public DateTime DateCreated { get; set; }
        public Currency Currency { get; set; } 
    }
}
