using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Wincubate.RepositoryExamples.Data;

namespace Wincubate.RepositoryExamples
{
    class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public InMemoryProductRepository( params Product[] products )
        {
            _products = new List<Product>(products);
        }

        public Product GetById( int id ) => _products.Single(p => p.Id == id);

        public IQueryable<Product> GetAll() => _products
            .AsQueryable();

        public IQueryable<Product> Find( Expression<Func<Product, bool>> filter ) => _products
            .AsQueryable()
            .Where(filter);

        public void Add( Product product ) => _products.Add(product);

        public void Remove( Product product ) => _products.Remove(product);
    }
}
