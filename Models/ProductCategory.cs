using System;
using System.Collections.Generic;

namespace jannieCouture.Models
{
    public class ProductCategory
    {
        public ProductCategory()
        {
        }

        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public string[] MarketNames { get; set; } 
        public string ImageUrl { get; set; }
        public string[] Tags { get; set; }
        public List<Product> Products { get; set; }
    }

}
