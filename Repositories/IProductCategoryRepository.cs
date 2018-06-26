using System;
using System.Collections.Generic;
using jannieCouture.Models;

namespace jannieCouture.Repositories
{
    public interface IProductCategoryRepository
    {
        IEnumerable<ProductCategory> productCategories { get; }
        ProductCategory AddProductCategory(ProductCategory newProductTag);
    }
}
