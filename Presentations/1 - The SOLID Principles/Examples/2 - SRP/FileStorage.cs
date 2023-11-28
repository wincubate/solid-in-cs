namespace Wincubate.Module1;

class FileStorage
{
    public Task<string> GetDataAsStringAsync(string sourceFilePath)
    {
        return File.ReadAllTextAsync(sourceFilePath);
    }

    public Task StoreDataAsStringAsync(
        string destinationFilePath,
        string outputDataAsString)
    {
        return File.WriteAllTextAsync(destinationFilePath, outputDataAsString);
    }
}
