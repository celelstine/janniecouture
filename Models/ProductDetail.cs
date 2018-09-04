using System;
using System.Collections.Generic;

namespace jannieCouture.Models
{
    public class ProductDetail
    {
        public ProductDetail()
        {
        }
        public int ProductDetailID { get; set; }
        public string Name { get; set; }
        public string[] MarketNames { get; set; } 
        public string ImageUrl { get; set; }
        public double Price { get; set;  }
        public int? MeasurementCategory { get; set; }
        public string Currency { get; set; }
        public List<ProductDetailPrice> ProductDetailPrices { get; set; }
    }
}
