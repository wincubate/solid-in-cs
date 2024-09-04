using Microsoft.Extensions.DependencyInjection;
using Polly;
using Wincubate.Module1.Exceptions;

namespace Wincubate.Module1.Storage.Resilience;

internal class RetryingWriteStorageProxy : IWriteStorage
{
    private readonly IWriteStorage _proxee;

    public RetryingWriteStorageProxy([FromKeyedServices("composite")] IWriteStorage proxee) =>
        _proxee = proxee;

    public async Task StoreDataAsStringAsync(string outputDataAsString)
    {
        try
        {
            IAsyncPolicy policy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(
                    3,
                    _ => TimeSpan.FromSeconds(2),
                    (exception, timespan) =>
                    {
                        Console.WriteLine($"Retrying in {timespan} due to error: {exception.Message}");
                    })
                ;
            await policy.ExecuteAsync(() => _proxee.StoreDataAsStringAsync(outputDataAsString));
        }
        catch (Exception exception)
        {
            string message = $"An exception occurred after retrying";
            throw new StockStorageException(message, exception);
        }
    }
}
