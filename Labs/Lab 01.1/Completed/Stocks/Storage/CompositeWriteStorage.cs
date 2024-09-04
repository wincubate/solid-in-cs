namespace Wincubate.Module1.Storage;

class CompositeWriteStorage : IWriteStorage
{
    private readonly IEnumerable<IWriteStorage> _storages;

    public CompositeWriteStorage(IEnumerable<IWriteStorage> storages)
    {
        _storages = storages;
    }

    public CompositeWriteStorage(params IWriteStorage[] storages)
        : this(storages.AsEnumerable())
    {
    }

    public async Task StoreDataAsStringAsync(string outputDataAsString)
    {
        await Task.WhenAll(_storages
            .Select(storage => storage.StoreDataAsStringAsync(outputDataAsString)));
    }
}
