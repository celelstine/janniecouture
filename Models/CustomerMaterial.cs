using System;
namespace jannieCouture.Models
{
    public class CustomerMaterial
    {
        public CustomerMaterial()
        {
        }

        public int CustomerMaterialId { get; set; }
        public Material Material { get; set; }
        public double Quantity { get; set; }
        public DateTime? DateDelivered { get; set; }
        public DateTime DatePlaced { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
    }
}
