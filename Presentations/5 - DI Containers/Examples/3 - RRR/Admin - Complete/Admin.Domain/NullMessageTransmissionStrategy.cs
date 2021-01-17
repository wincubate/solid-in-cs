using Admin.Domain.Interfaces;
using System.Threading.Tasks;

namespace Admin.Domain
{
    public class NullMessageTransmissionStrategy : IMessageTransmissionStrategy
    {
        // Deliberately do nothing! :-)
        public Task TransmitAsync(User recipient, InstantiatedMessage instance) => Task.CompletedTask;
    }
}
