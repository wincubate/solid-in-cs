using System.Collections.Generic;
using System.Threading.Tasks;
using Wincubate.Module1.DomainLayer;

namespace Wincubate.Module1
{
    class StockAnalyzer
    {
        private readonly IReadStorage _readStorage;
        private readonly IWriteStorage _writeStorage;
        private readonly IParser _parser;
        private readonly ISerializer _serializer;

        public StockAnalyzer(
            IReadStorage readStorage,
            IWriteStorage writeStorage,
            IParser parser,
            ISerializer serializer
        )
        {
            _readStorage = readStorage;
            _writeStorage = writeStorage;
            _parser = parser;
            _serializer = serializer;
        }

        public async Task ProcessAsync()
        {
            string inputDataAsString = await _readStorage.GetDataAsStringAsync();
            IEnumerable<StockPosition> stockPositions = _parser.Parse(inputDataAsString);

            Computation computation = new Computation();
            IEnumerable<StockPosition> output = computation.Execute(stockPositions);

            string outputDataAsString = _serializer.SerializeData(output);

            await _writeStorage.StoreDataAsStringAsync(outputDataAsString);
        }
    }
}
