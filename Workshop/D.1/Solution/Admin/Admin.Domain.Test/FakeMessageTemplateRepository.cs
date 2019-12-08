using Admin.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Admin.Domain.Test
{
    internal class FakeMessageTemplateRepository : IMessageTemplateRepository
    {
        private readonly IQueryable<MessageTemplate> _messageTemplates;

        public FakeMessageTemplateRepository(IEnumerable<MessageTemplate> messageTemplates)
        {
            _messageTemplates = messageTemplates
                .AsQueryable()
                ;
        }

        public FakeMessageTemplateRepository(params MessageTemplate[] messageTemplates)
            : this(messageTemplates.AsEnumerable())
        {
        }

        public IQueryable<MessageTemplate> GetAll() => _messageTemplates;

        public IQueryable<MessageTemplate> GetAll(Expression<Func<MessageTemplate, bool>> filter) =>
            _messageTemplates.Where(filter);
    }
}
