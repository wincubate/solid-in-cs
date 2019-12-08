using Admin.Domain.Interfaces;
using Admin.Domain.Logging.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Domain
{
    public class Messenger
    {
        private readonly IMessageTemplateRepository _repository;
        private readonly IMessageTransmissionStrategy _strategy;
        private readonly ILoggerFactory _loggerFactory;

        private readonly TextSubstitutor _substitutor;

        public Messenger(
            IMessageTemplateRepository repository,
            IMessageTransmissionStrategy strategy,
            ILoggerFactory loggerFactory
        )
        {
            _repository = repository;
            _strategy = strategy;
            _loggerFactory = loggerFactory;

            _substitutor = new TextSubstitutor();
        }

        public async Task SendAsync(Message message)
        {
            ILogger logger = _loggerFactory.Create(nameof(Messenger));
            logger.Info( "Sending message", message );

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

            logger.Info("Message instance successfully sent", instance);
        }
    }
}
