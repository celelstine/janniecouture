using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace jannieCouture.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
        }
        public int ShoppingCartId { get; set; }
        public int? USerId { get; set; }
        public string Email { get; set; }
		[DefaultValue(typeof(DateTime), "")]
		public DateTime DateCreated { get; set; }
        public double TotalCost { get; set; }
        public int Numberitems { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime ExpiresOn { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set;  }
    }
}
