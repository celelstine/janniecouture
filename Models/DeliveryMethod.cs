using System;
namespace jannieCouture.Models
{
    public class DeliveryMethod
    {
        public DeliveryMethod()
        {
        }

        public int DeliveryMethodId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
        public double Cost { get; set; }
        public string TimeToDeliver { get; set; }
    }
}
