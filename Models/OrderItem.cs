using System;
namespace jannieCouture.Models
{
    public class OrderItem
    {
        public OrderItem()
        {
        }

        public int OrderItemId { get; set; }
        public Order Order { get; set; }
        public ShoppingCartItem ShoppingCartItem { get; set;  }
        public string Notes { get; set; }
        public DeliveryClass DeliveryClass { get; set; }
        public OrderStatus OrderStatus { get; set;  }
    }
}
