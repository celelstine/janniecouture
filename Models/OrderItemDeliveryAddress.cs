using System;
namespace jannieCouture.Models
{
    public class OrderItemDeliveryAddress
    {
        public OrderItemDeliveryAddress()
        {
        }

        public int OrderItemDeliveryAddressId { get; set; }
        public OrderItem OrderItem { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
    }
}
