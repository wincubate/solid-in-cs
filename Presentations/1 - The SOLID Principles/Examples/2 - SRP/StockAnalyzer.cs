using System.Collections.Generic;
using System.Threading.Tasks;
using Wincubate.Solid.Module01.DomainLayer;

namespace Wincubate.Solid.Module01
{
    class StockAnalyzer
    {
        private readonly FileStorage _storage;
        private readonly Parser _parser;
        private readonly CsvSerializer _serializer;

        public StockAnalyzer()
        {
            _storage = new FileStorage();
            _parser = new Parser();
            _serializer = new CsvSerializer();
        }

        public async Task ProcessAsync(string sourceFilePath, string destinationFilePath)
        {
            string inputDataAsString = await _storage.GetDataAsStringAsync(sourceFilePath);
            IEnumerable<StockPosition> stockPositions = _parser.Parse(inputDataAsString);

            Computation computation = new Computation();
            IEnumerable<StockPosition> output = computation.Execute(stockPositions);

            string outputDataAsString = _serializer.SerializeData(output);

            await _storage.StoreDataAsStringAsync(destinationFilePath, outputDataAsString);
        }
    }
}
