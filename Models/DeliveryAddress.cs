using System;
namespace jannieCouture.Models
{
    public class DeliveryAddress
    {
        public DeliveryAddress()
        {
        }

        public int DeliveryAddressId { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }
        public string Town { get; set; }
        public string LineAddress { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string Note { get; set; }
        public int? UserId { get; set; }
        public DeliveryStatus DeliveryStatus { get; set;  }
    }
}
