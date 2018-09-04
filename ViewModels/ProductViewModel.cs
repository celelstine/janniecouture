using System;
using System.ComponentModel.DataAnnotations;
namespace jannieCouture.ViewModels
{
    public class ProductViewModel
    {
		[Required]
		public string Name { get; set; }
		public string[] MarketNames { get; set; }
		public string ImageUrl { get; set; }
        public string PriceCurrent { get; set; }
        public string PriceRange { get; set; }
		public string[] Tags { get; set; }
        [Required]
        public int ProductCategoryID { get; set; }
        public int MeasurementCategory
        {
            get;
            set;
        }

        public ProductViewModel()
        {
        }
    }
}
