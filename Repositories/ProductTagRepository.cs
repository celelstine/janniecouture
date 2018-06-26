using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using jannieCouture.Models;

namespace jannieCouture.Repositories
{
    public class ProductTagRepository: IProductTagRepository

    {
        private readonly AppDbContext _appDbContext;
        public ProductTagRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<ProductTag> ProductTags => _appDbContext.ProductTag.ToList();

		public ProductTag AddProductTag(ProductTag productTag)
        {
            _appDbContext.ProductTag.Add(productTag);
            _appDbContext.SaveChanges();
            return productTag;
        }
    }
}
