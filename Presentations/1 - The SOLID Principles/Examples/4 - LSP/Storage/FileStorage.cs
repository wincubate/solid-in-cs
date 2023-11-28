namespace Wincubate.Module1;

class FileStorage : IStorage
{
    public async Task<string> GetDataAsStringAsync(string sourceFilePath)
    {
        try
        {
            return await File.ReadAllTextAsync(sourceFilePath);
        }
        catch (Exception exception)
        {
            string message = $"Could not load from \"{sourceFilePath}\"";
            throw new StockStorageException(message, exception);
        }
    }

    public async Task StoreDataAsStringAsync(string destinationFilePath, string outputDataAsString)
    {
        try
        {
            await File.WriteAllTextAsync(destinationFilePath, outputDataAsString);
        }
        catch (Exception exception)
        {
            string message = $"Could not write to \"{destinationFilePath}\"";
            throw new StockStorageException(message, exception);
        }
    }
}
