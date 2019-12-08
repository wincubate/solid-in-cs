using Admin.Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Domain
{
    public class Messenger
    {
        private readonly IMessageTemplateRepository _repository;
        private readonly IMessageTransmissionStrategy _strategy;
        private readonly TextSubstitutor _substitutor;

        public Messenger(
            IMessageTemplateRepository repository,
            IMessageTransmissionStrategy strategy
        )
        {
            _repository = repository;
            _strategy = strategy;

            _substitutor = new TextSubstitutor();
        }

        public async Task SendAsync(Message message)
        {
            MessageTemplate messageTemplate = _repository
                .GetAll( mt => mt.Kind == message.MessageTemplateKind && mt.Culture == message.Culture)
                .SingleOrDefault()
                ?? throw new AdminException(
                    message: $"No available message template with id {message.MessageTemplateKind} in culture {message.Culture}",
                    reason: AdminExceptionReason.Messaging
                )
                ;

            string instantiatedBody = _substitutor.Substitute(messageTemplate, message.Parameters);
            InstantiatedMessage instance = new InstantiatedMessage(
                messageTemplate.Subject, 
                instantiatedBody
            );

            await _strategy.TransmitAsync(message.Recipient, instance);
        }
    }
}
