using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Wincubate.RepositoryExamples.Data;
using Wincubate.RepositoryExamples.Data.EF;

namespace Wincubate.RepositoryExamples
{
    class ProductRepository : IProductRepository
    {
        private readonly ProductsContext _context;

        public ProductRepository(ProductsContext context)
        {
            _context = context;
        }

        public Product GetById(int id) => _context.Products
            .Single(p => p.Id == id);

        public IEnumerable<Product> GetAll() => _context.Products
            .ToList()
            ;

        public IEnumerable<Product> Find(Expression<Func<Product, bool>> filter) => _context.Products
            .Where(filter)
            .ToList()
            ;

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public void AddRange(IEnumerable<Product> products)
        {
            _context.Products.AddRange(products);
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }

        public void RemoveRange(IEnumerable<Product> products)
        {
            _context.Products.RemoveRange(products);
        }

        public IEnumerable<Product> GetForCategory(Category? category) => _context.Products
            .Where(p => p.Category == category)
            .ToList()
            ;
    }
}
