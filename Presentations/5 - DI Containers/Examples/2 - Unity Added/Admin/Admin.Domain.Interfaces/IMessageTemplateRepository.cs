using System;
using System.Linq;
using System.Linq.Expressions;

namespace Admin.Domain.Interfaces
{
    public interface IMessageTemplateRepository
    {
        IQueryable<MessageTemplate> GetAll();
        IQueryable<MessageTemplate> GetAll(Expression<Func<MessageTemplate, bool>> filter);
    }
}
