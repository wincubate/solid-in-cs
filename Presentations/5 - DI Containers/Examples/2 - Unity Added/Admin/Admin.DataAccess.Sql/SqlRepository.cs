using Admin.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Admin.DataAccess.Sql
{
    public class SqlRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext Context { get; }

        public SqlRepository(DbContext context)
        {
            Context = context;
        }

        public Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken) =>
            Context.Set<TEntity>()
                .FindAsync(id, cancellationToken)
                ;

        public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken) =>
            Context.Set<TEntity>()
                .ToListAsync(cancellationToken)
                .ContinueWith(t => t.Result.AsEnumerable())
                ;

        public Task<IEnumerable<TEntity>> FindAsync(
            Expression<Func<TEntity, bool>> filter,
            CancellationToken cancellationToken
        ) =>
            Context.Set<TEntity>()
                .Where(filter)
                .ToListAsync(cancellationToken)
                .ContinueWith(t => t.Result.AsEnumerable())
                ;
    }
}
