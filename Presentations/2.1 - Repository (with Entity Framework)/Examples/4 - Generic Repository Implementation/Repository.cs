using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Wincubate.RepositoryExamples
{
    class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext Context { get; }

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity GetById(int id) =>
            Context.Set<TEntity>().Find(id);

        public IEnumerable<TEntity> GetAll() =>
            Context.Set<TEntity>()
                .ToList()
                ;

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter) =>
            Context.Set<TEntity>()
                .Where(filter)
                ;

        public void Add(TEntity entity) =>
           Context.Set<TEntity>().Add(entity);

        public void AddRange(IEnumerable<TEntity> entities) =>
           Context.Set<TEntity>().AddRange(entities);

        public void Remove(TEntity entity) =>
            Context.Set<TEntity>().Remove(entity);
        public void RemoveRange(IEnumerable<TEntity> entities) =>
           Context.Set<TEntity>().RemoveRange(entities);
    }
}
