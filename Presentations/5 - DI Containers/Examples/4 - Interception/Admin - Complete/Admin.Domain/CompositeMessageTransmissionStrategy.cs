using Admin.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Domain
{
    public class CompositeMessageTransmissionStrategy : IMessageTransmissionStrategy
    {
        private readonly IEnumerable<IMessageTransmissionStrategy> _strategies;

        public CompositeMessageTransmissionStrategy(params IMessageTransmissionStrategy[] strategies)
        {
            _strategies = strategies;
        }

        async public Task TransmitAsync(User recipient, InstantiatedMessage instance)
        {
            await Task.WhenAll(_strategies.
                Select( s => s.TransmitAsync( recipient, instance ) )
            );
        }
    }
}
