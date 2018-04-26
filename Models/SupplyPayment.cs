using System;
using System.Collections.Generic;

namespace jannieCouture.Models
{
    public class SupplyPayment
    {
        public SupplyPayment()
        {
        }

        public int SupplyPaymentId { get; set; }
        public double TotalPaid { get; set; }
        public double Balance { get; set; }
        public List<SupplyPaymentHistory> SupplyPaymentHistory { get; set; }
        public Supply Supply { get; set; }
    }
}
