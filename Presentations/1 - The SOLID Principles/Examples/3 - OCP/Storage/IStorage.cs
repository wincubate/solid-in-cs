namespace Wincubate.Module1;

interface IStorage
{
    Task<string> GetDataAsStringAsync(string sourceFilePath);
    Task StoreDataAsStringAsync(string destinationFilePath, string outputDataAsString);
}
