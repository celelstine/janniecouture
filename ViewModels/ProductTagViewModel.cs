using System;
using System.ComponentModel.DataAnnotations;
namespace jannieCouture.ViewModels
{
    public class ProductTagViewModel
    {
        public ProductTagViewModel()
        {
        }

		[Required]
		public string Name { get; set; }

        public string Description { get; set; }
    }
}
