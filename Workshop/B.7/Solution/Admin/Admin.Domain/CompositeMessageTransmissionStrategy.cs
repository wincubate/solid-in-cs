using Admin.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Domain
{
    public class CompositeMessageTransmissionStrategy : IMessageTransmissionStrategy
    {
        private readonly IEnumerable<IMessageTransmissionStrategy> _strategies;

        public CompositeMessageTransmissionStrategy(IEnumerable<IMessageTransmissionStrategy> strategies)
        {
            _strategies = strategies.ToList();
        }

        public CompositeMessageTransmissionStrategy(params IMessageTransmissionStrategy[] strategies) :
            this(strategies.AsEnumerable())
        {
        }
        
        public Task TransmitAsync(User recipient, InstantiatedMessage instance)
        {
            return Task.WhenAll(_strategies.Select(s => s.TransmitAsync(recipient, instance)));
        }
    }
}
