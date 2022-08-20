using System.Collections.Generic;
using System.Linq;
using Wincubate.RepositoryExamples.Data;

namespace Wincubate.RepositoryExamples;

class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products;

    public InMemoryProductRepository(params Product[] products)
    {
        _products = new List<Product>(products);
    }

    public Product GetById(int id) => _products.Single(p => p.Id == id);

    public IEnumerable<Product> GetAll() => _products
        .ToList();

    public IEnumerable<Product> GetForCategory(Category? category) => _products
        .Where(p => p.Category == category)
        .ToList();

    public void Add(Product product)
    {
        int existingIndex = _products.FindIndex(p => p.Id == product.Id);
        if (existingIndex >= 0)
        {
            _products[existingIndex] = product;
        }
        else
        {
            _products.Add(product);
        }
    }

    public void Remove(Product product)
    {
        _products.Remove(product);
    }
}
