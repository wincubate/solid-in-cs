using Admin.Domain.Interfaces;

namespace Admin.DataAccess.Sql
{
    public class SqlMessageTemplateRepository :
        SqlRepository<MessageTemplate>,
        IMessageTemplateRepository
    {
        protected MessageTemplateContext MessageTemplateContext => Context as MessageTemplateContext;

        public SqlMessageTemplateRepository(MessageTemplateContext context) : base(context)
        {
        }

        // Add methods specific to MessageTemplates here
    }
}
