using System;
namespace jannieCouture.Models
{
    public class Supply
    {
        public Supply()
        {
        }


        public int SupplyId { get; set; }
        public Vendor Vendor { get; set; }
        public Material Materail { get; set; }
        public double Quantity { get; set; }
        public DateTime? DatePlaced { get; set; }
        public DateTime? DateFullfilled { get; set; }
        public SupplyRequestStatus SupplyRequestStatus { get; set; } 
    }
}
