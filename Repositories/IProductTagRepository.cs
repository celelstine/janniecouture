using System;
using System.Collections.Generic;
using jannieCouture.Models;

namespace jannieCouture.Repositories
{
    public interface IProductTagRepository
    {
        IEnumerable<ProductTag> ProductTags { get; }
        ProductTag AddProductTag(ProductTag newProductTag);
    }
}
