using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace jannieCouture.Models
{
    public class Order
    {
        public Order()
        {
        }

        public int OrderId { get; set; }
        public string OrderSerial { get; set; }
        public int UserId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
		[DefaultValue(typeof(DateTime), "")]
		public DateTime DateCreated { get; set; }

        public int? OrderPaymentID { get; set; }
        public virtual OrderPayment OrderPayment { get; set; }
        public string Note { get; set; }
    }
}