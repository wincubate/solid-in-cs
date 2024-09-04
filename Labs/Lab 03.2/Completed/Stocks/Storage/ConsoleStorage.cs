namespace Wincubate.Module1.Storage;

class ConsoleStorage : IStorage
{
    public Task<string> GetDataAsStringAsync()
    {
        string? s = Console.ReadLine();
        return Task.FromResult(s ?? string.Empty);
    }

    public Task StoreDataAsStringAsync(string outputDataAsString)
    {
        Console.WriteLine(outputDataAsString);
        return Task.CompletedTask;
    }
}
