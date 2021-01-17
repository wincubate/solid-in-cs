using Admin.Domain.Interfaces;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Admin.Domain.Sms
{
    public class TwilioSmsTransmissionStrategy : IMessageTransmissionStrategy
    {
        async public Task TransmitAsync(User recipient, InstantiatedMessage instance)
        {
            TwilioClient.Init(TwilioConstants.AccountSid, TwilioConstants.AuthToken);

            string contents = string.Format(TwilioConstants.ContentsFormat,
                instance.Subject.ToUpper(),
                instance.Body
            );
            MessageResource mr = await MessageResource.CreateAsync(
                to: new PhoneNumber(recipient.Phone),
                from: new PhoneNumber(TwilioConstants.FromPhone),
                body: contents
            );
        }
    }
}
