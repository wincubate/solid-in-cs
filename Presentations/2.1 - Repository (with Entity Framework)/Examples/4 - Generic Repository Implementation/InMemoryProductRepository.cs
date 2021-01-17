using System.Collections.Generic;
using System.Linq;
using Wincubate.RepositoryExamples.Data;

namespace Wincubate.RepositoryExamples
{
    class InMemoryProductRepository : InMemoryRepository<Product>, IProductRepository
    {
        public InMemoryProductRepository(params Product[] entities) : base(entities)
        {
        }

        public IEnumerable<Product> GetForCategory(Category? category) =>
            _elements
                .Where(product => product.Category == category)
                .ToList()
                ;

    }
}
