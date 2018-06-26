using System;
namespace jannieCouture.Models
{
    public class ShoppingCartItem
    {
        public ShoppingCartItem()
        {
        }
        public int ShoppingCartItemId { get; set; }
        public ShoppingCart ShoppingCart { get; set;  } 
        public ProductDetail ProductDetail { get; set; }
        public double Price { get; set; }
        public int Quantiy { get; set;  }
        public CartStatus CartStatus { get; set;  }
    }
}
