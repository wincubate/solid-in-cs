using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Wincubate.Module1.Exceptions;

namespace Wincubate.Module1.Storage.Sms;

internal class TwilioSmsWriteStorage : IWriteStorage
{
    private readonly string _recipientPhone;

    public TwilioSmsWriteStorage(string recipientPhone) =>
        _recipientPhone = recipientPhone;

    public async Task StoreDataAsStringAsync(string outputDataAsString)
    {
        try
        {
            TwilioClient.Init(TwilioConstants.AccountSid, TwilioConstants.AuthToken);

            _ = await MessageResource.CreateAsync(
                to: new PhoneNumber(_recipientPhone),
                from: new PhoneNumber(TwilioConstants.FromPhone),
                body: outputDataAsString
            );
        }
        catch (Exception exception)
        {
            string message = $"Could not send an SMS to {_recipientPhone}";
            throw new StockStorageException(message, exception);
        }
    }
}
