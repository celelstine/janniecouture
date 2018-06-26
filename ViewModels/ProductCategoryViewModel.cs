using System;
using System.ComponentModel.DataAnnotations;
            
namespace jannieCouture.ViewModels
{
    public class ProductCategoryViewModel
    {
        public ProductCategoryViewModel()
        {
        }

		[Required]
		public string Name { get; set; }
		public string[] MarketNames { get; set; }
		public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string[] Tags { get; set; }
    }
}
