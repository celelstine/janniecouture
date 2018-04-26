using System;
using System.Collections.Generic;

namespace jannieCouture.Models
{
    public class ProductDetailPrice
    {
        public ProductDetailPrice()
        {
        }

        public int ProductDetailPriceId { get; set; }
        public double Price { get; set; }
        public ProductDetail ProductDetail { get; set; }
        public string Currency { get; set; }
        public AgeRange AgeRange { get; set; }
        public double? Discount { get; set; }
        public ProductDetailPriceHistory ProductDetailPriceHistory { get; set; }
    }
}
