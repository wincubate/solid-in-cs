using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Wincubate.RepositoryExamples;

class InMemoryRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly List<TEntity> _elements;

    public InMemoryRepository( params TEntity[] entities )
    {
        _elements = new List<TEntity>(entities);
    }

    // Kinda hack, but there is a good reason... :-)
    public TEntity GetById(int id)
    {
        foreach (dynamic entity in _elements)
        {
            if( entity.Id == id )
            {
                return entity;
            }
        }

        return null;
    }

    public IEnumerable<TEntity> GetAll() => _elements
        .ToList()
        ;

    public IEnumerable<TEntity> Find( Expression<Func<TEntity, bool>> filter ) => _elements
        .AsQueryable()
        .Where(filter)
        ;

    public void Add( TEntity element ) =>
        _elements.Add(element);

    public void AddRange(IEnumerable<TEntity> entities) =>
        _elements.AddRange(entities);

    public void Remove( TEntity element ) =>
        _elements.Remove(element);

    public void RemoveRange(IEnumerable<TEntity> entities) =>
        _elements.RemoveAll(entity => entities.Contains(entity));
}
