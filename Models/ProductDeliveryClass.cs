using System;
namespace jannieCouture.Models
{
    public class ProductDeliveryClass
    {
        public ProductDeliveryClass()
        {
        }

        public int ProductDeliveryClassId { get; set; }
        public DeliveryClass DeliveryClass { get; set; }
        public ProductDetail ProductDetail { get; set; }
        public double PercentageAdded { get; set; }
    }
}
