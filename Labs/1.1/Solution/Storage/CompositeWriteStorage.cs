using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wincubate.Solid
{
    class CompositeWriteStorage : IWriteStorage
    {
        private readonly IEnumerable<IWriteStorage> _storages;

        public CompositeWriteStorage(IEnumerable<IWriteStorage> storages) =>
            _storages = storages.ToList();

        public CompositeWriteStorage(params IWriteStorage[] storages) :
            this(storages.AsEnumerable())
        {
        }

        public Task StoreDataAsStringAsync(string outputDataAsString) =>
            Task.WhenAll(_storages.Select(storage => storage.StoreDataAsStringAsync(outputDataAsString)));
    }
}
