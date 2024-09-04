namespace Wincubate.Module1;

interface IWriteStorage
{
    Task StoreDataAsStringAsync(string outputDataAsString);
}
