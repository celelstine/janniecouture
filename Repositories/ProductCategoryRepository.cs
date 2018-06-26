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
    }
}
