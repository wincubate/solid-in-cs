using Admin.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Admin.Domain.Test
{
    internal class FakeAsyncMessageTemplateRepository : IMessageTemplateRepository
    {
        private readonly List<MessageTemplate> _messageTemplates;

        public FakeAsyncMessageTemplateRepository(IEnumerable<MessageTemplate> messageTemplates)
        {
            _messageTemplates = messageTemplates
                .ToList()
                ;
        }
        public FakeAsyncMessageTemplateRepository(params MessageTemplate[] messageTemplates)
            : this(messageTemplates.AsEnumerable())
        {
        }

        public Task<MessageTemplate> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
            Task.FromResult(_messageTemplates
                .Single(mt => mt.Id == id)
            );

        public Task<IEnumerable<MessageTemplate>> GetAllAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult(_messageTemplates
                .AsEnumerable()
            );

        public Task<IEnumerable<MessageTemplate>> FindAsync(Expression<Func<MessageTemplate, bool>> filter, CancellationToken cancellationToken = default) =>
            Task.FromResult(_messageTemplates
                .AsQueryable()
                .Where(filter)
                .AsEnumerable()
            );
    }
}
