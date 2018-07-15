using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using jannieCouture.Models;
namespace jannieCouture.Repositories
{
    public class ProductCategoryRepository: IProductCategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductCategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<ProductCategory> productCategories => _appDbContext.ProductCategory;

		public ProductCategory AddProductCategory(ProductCategory newProductTag)
        {
			_appDbContext.ProductCategory.Add(newProductTag);
			_appDbContext.SaveChanges();
			return newProductTag;
        }

        // we are not using this method yet
		public ProductCategory EditProductCategory(
            int productCategoryID, 
            string ImageUrl,
            string MarketNames,
            string Tags,
            string Name
        )
		{
			// check that a product category does not exist with same name
			ProductCategory foundCategory = _appDbContext.ProductCategory
				.Where(pc => pc.ProductCategoryID == productCategoryID)
				.FirstOrDefault();
			foundCategory.ImageUrl = ImageUrl;
			foundCategory.Name = Name;
			foundCategory.MarketNames = MarketNames.Split(',');
			foundCategory.Tags = Tags.Split(',');
			_appDbContext.SaveChanges();
			return foundCategory;
		}
    }
}
