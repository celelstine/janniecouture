using System;
using System.Collections.Generic;

namespace jannieCouture.Models
{
    public class PaymentMethod
    {
        public PaymentMethod()
        {
        }

        public int PaymentMethodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<OrderPaymentHistory> OrderPaymentHistories { get; set; }
    }
}
