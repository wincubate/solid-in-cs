using System.Collections.Generic;
using System.Linq;
using Wincubate.RepositoryExamples.Data;
using Wincubate.RepositoryExamples.Data.EF;

namespace Wincubate.RepositoryExamples;

class ProductRepository : Repository<Product>, IProductRepository
{
    protected ProductsContext ProductsContext => Context as ProductsContext;

    public ProductRepository(ProductsContext context) : base(context)
    {
    }

    public IEnumerable<Product> GetForCategory(Category? category) =>
        ProductsContext.Products
            .Where(product => product.Category == category)
            .ToList()
            ;
}
