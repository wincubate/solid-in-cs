using System.Collections.Generic;
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

        public void Process( string sourceFilePath, string destinationFilePath)
        {
            string inputDataAsString = _storage.GetDataAsString(sourceFilePath);
            IEnumerable<StockPosition> stockPositions = _parser.Parse(inputDataAsString);

            Computation computation = new Computation();
            IEnumerable<StockPosition> output = computation.Execute(stockPositions);

            string outputDataAsString = _serializer.SerializeData(output);

            _storage.StoreDataAsString(destinationFilePath, outputDataAsString);
        }
    }
}
