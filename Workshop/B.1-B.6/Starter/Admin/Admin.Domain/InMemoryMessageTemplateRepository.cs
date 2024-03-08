using Admin.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Admin.Domain
{
    public class InMemoryMessageTemplateRepository : IMessageTemplateRepository
    {
        private readonly List<MessageTemplate> _messageTemplates;

        public InMemoryMessageTemplateRepository()
        {
            _messageTemplates = new List<MessageTemplate>
            {
                new MessageTemplate
                {
                    Id = 1,
                    Kind = "UserIsCreatedOk",
                    Culture = "en",
                    Subject = "Account created",
                    BodyTemplate = "Dear {0}. Your account with Cinemas 'R Us was created successfully. :-)"
                },
                new MessageTemplate
                {
                    Id = 2,
                    Kind = "UserIsCreatedOk",
                    Culture = "da",
                    Subject = "Konto oprettet",
                    BodyTemplate = "Kære {0}. Din konto hos Cinemas 'R Us er nu oprettet. :-)"
                },
                new MessageTemplate
                {
                    Id = 3,
                    Kind = "UserIsDeletedOk",
                    Culture = "en",
                    Subject = "Account deleted",
                    BodyTemplate = "Dear {0}. We''re so sad to see you leave... :-("
                },
                new MessageTemplate
                {
                    Id = 4,
                    Kind = "UserIsDeletedOk",
                    Culture = "da",
                    Subject = "Konto slettet",
                    BodyTemplate = "Kære {0}. Vi er så kede af, at du forlader os... :-("
                }
            };
        }

        public MessageTemplate GetById(int id)
        {
            return _messageTemplates
                .Single(mt => mt.Id == id);
        }

        public MessageTemplate GetByTemplateKindCulture(string kind, string culture)
        {
            return _messageTemplates
                .Single(mt => mt.Kind == kind && mt.Culture == culture);
        }
    }
}
