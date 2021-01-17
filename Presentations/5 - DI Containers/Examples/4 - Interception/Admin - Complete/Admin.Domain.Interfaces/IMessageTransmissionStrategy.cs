using System.Threading.Tasks;

namespace Admin.Domain.Interfaces
{
    public interface IMessageTransmissionStrategy
    {
        Task TransmitAsync(User recipient, InstantiatedMessage instance);
    }
}
