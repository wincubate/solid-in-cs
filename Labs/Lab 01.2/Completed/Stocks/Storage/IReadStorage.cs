namespace Wincubate.Module1.Storage;

interface IReadStorage
{
    Task<string> GetDataAsStringAsync();
}
