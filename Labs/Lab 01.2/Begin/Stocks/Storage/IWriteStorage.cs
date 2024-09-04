namespace Wincubate.Module1.Storage;

interface IWriteStorage
{
    Task StoreDataAsStringAsync(string outputDataAsString);
}
