namespace Wincubate.Module1;

class FileStorage : IStorage
{
    public string SourcePath { get; }
    public string DestinationPath { get; }

    public FileStorage(string sourcePath, string destinationPath)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    public async Task<string> GetDataAsStringAsync()
    {
        try
        {
            return await File.ReadAllTextAsync(SourcePath);
        }
        catch (Exception exception)
        {
            string message = $"Could not load from \"{SourcePath}\"";
            throw new StockStorageException(message, exception);
        }
    }

    public async Task StoreDataAsStringAsync(string outputDataAsString)
    {
        try
        {
            await File.WriteAllTextAsync(DestinationPath, outputDataAsString);
        }
        catch (Exception exception)
        {
            string message = $"Could not write to \"{DestinationPath}\"";
            throw new StockStorageException(message, exception);
        }
    }
}
