using System;
using System.Collections.Generic;

namespace jannieCouture.Models
{
    public class OrderPayment
    {
        public OrderPayment()
        {
        }

        public int OrderPaymentId { get; set; }
        public double TotalPaid { get; set; }
        public double Balance { get; set; }
        public List<OrderPaymentHistory> OrderPaymentHistory { get; set; }
        public Order Order { get; set; }
    }
}
