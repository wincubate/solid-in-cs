using Admin.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Admin.Domain.Test
{
    internal class MessageTransmissionStrategyTestSpy : IMessageTransmissionStrategy
    {
        public IEnumerable<(User recipient, InstantiatedMessage instance)> Sent => _sent;
        private readonly IList<(User recipient, InstantiatedMessage instance)> _sent;

        public MessageTransmissionStrategyTestSpy()
        {
            _sent = new List<(User recipient, InstantiatedMessage instance)>();
        }

        public Task TransmitAsync(User recipient, InstantiatedMessage instance)
        {
            _sent.Add((recipient, instance));

            return Task.CompletedTask;
        }
    }
}
