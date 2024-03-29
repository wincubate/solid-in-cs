using System.Collections.Generic;
using System.Linq;
using Wincubate.RepositoryExamples.Data;
using Wincubate.RepositoryExamples.Data.EF;

namespace Wincubate.RepositoryExamples;

class ProductRepository : IProductRepository
{
    private readonly ProductsContext _context;

    public ProductRepository(ProductsContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAll() => _context.Products
        .ToList();

    public IEnumerable<Product> GetForCategory(Category? category) => _context.Products
        .Where(p => p.Category == category)
        .ToList();

    public Product GetById(int id) => _context.Products
        .Single(p => p.Id == id);

    //public void Add( Product product )
    //{
    //    _context.Products.Add(product ?? throw new ArgumentNullException(nameof(product)));
    //}

    //public void Remove( Product product )
    //{
    //    _context.Products.Remove(product ?? throw new ArgumentNullException(nameof(product)));
    //}
}
