using System.Collections.Generic;
using Wincubate.RepositoryExamples.Data;

namespace Wincubate.RepositoryExamples;

interface IProductRepository : IRepository<Product>
{
    IEnumerable<Product> GetForCategory(Category? category);
}
