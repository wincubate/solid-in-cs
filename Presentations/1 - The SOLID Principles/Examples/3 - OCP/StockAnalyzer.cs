using System.Collections.Generic;
using System.Threading.Tasks;
using Wincubate.Solid.DomainLayer;

namespace Wincubate.Solid
{
    class StockAnalyzer
    {
        private readonly IStorage _storage;
        private readonly IParser _parser;
        private readonly ISerializer _serializer;

        public StockAnalyzer()
        {
            _storage = new FileStorage();
            //_parser = new CsvParser();
            _parser = new JsonParser();
            //_serializer = new CsvSerializer();
            _serializer = new JsonSerializer();
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
