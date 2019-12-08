using Admin.Domain.Interfaces;
using System.Threading.Tasks;

namespace Admin.Domain
{
    public class RedirectionMessageTransmissionStrategyProxy : IMessageTransmissionStrategy
    {
        private readonly IMessageTransmissionStrategy _proxee;
        private readonly RedirectionConfiguration _configuration;

        public RedirectionMessageTransmissionStrategyProxy(
            IMessageTransmissionStrategy proxee,
            RedirectionConfiguration configuration
        )
        {
            _proxee = proxee;
            _configuration = configuration;
        }

        public Task TransmitAsync(User recipient, InstantiatedMessage instance)
        {
            User redirectedRecipient = new User(
                name: recipient.Name,
                email: _configuration.Email ?? recipient.Email,
                phone: _configuration.Phone ?? recipient.Phone,
                preferredCulture: recipient.PreferredCulture
            );
            return _proxee.TransmitAsync(redirectedRecipient, instance);
        }
    }
}
