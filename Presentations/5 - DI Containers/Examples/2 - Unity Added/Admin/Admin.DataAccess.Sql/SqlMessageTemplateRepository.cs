using Admin.Domain.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Admin.DataAccess.Sql
{
    public class SqlMessageTemplateRepository : IMessageTemplateRepository
    {
        private readonly MessageTemplateContext _context;

        public SqlMessageTemplateRepository(MessageTemplateContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<MessageTemplate> GetAll() => _context.MessageTemplates;

        public IQueryable<MessageTemplate> GetAll(Expression<Func<MessageTemplate, bool>> filter)
            => _context.MessageTemplates.Where(filter);
    }
}
