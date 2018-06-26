using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace jannieCouture.Models
{
    public class Product
    {
        public Product()
        {
        }

        public int ProductID { get; set; }
        public string Name { get; set; }
        public string[] MarketNames { get; set; } 
        public string ImageUrl { get; set; }
        public string[] Tags { get; set; }
        public string PriceRange { get; set;  }
        public string PriceCurrent { get; set;  }
        [ForeignKey("ProductCategoryID")]
        public int ProductCategoryID { get; set; }
        //public virtual ProductCategory ProductCategory { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }
    }
}
