using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using jannieCouture.Models;

namespace jannieCouture.Repositories
{
    public class ProductRepository: IProductRepository
    {
		private readonly AppDbContext _appDbContext;
		public ProductRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

        public IEnumerable<Product> products => _appDbContext.Product;

		public Product AddProduct(Product newProduct)
		{
            _appDbContext.Product.Add(newProduct);
			_appDbContext.SaveChanges();
			return newProduct;
		}
    }
}
