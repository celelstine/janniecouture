using System;
using System.Collections.Generic;
using jannieCouture.Models;
namespace jannieCouture.Repositories
{
    public interface IProductRepository
    {
		IEnumerable<Product> products { get; }
		Product AddProduct(Product newProduct);
    }
}
