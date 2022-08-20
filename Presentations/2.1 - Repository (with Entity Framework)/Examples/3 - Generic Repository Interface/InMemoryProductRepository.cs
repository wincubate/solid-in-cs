using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        .ToList()
        ;

    public IEnumerable<Product> Find(Expression<Func<Product, bool>> filter) => _products
        .AsQueryable()
        .Where(filter)
        .ToList()
        ;

    public void Add(Product product) =>
        _products.Add(product);

    public void AddRange(IEnumerable<Product> products) =>
        _products.AddRange(products);

    public void Remove(Product product) =>
        _products.Remove(product);

    public void RemoveRange(IEnumerable<Product> products) => 
        _products.RemoveAll( p => products.Contains(p));

    public IEnumerable<Product> GetForCategory(Category? category) => _products
        .Where(p => p.Category == category)
        .ToList()
        ;
}
