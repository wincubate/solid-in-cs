using System.Collections.Generic;
using Wincubate.Solid.Module01.DomainLayer;

namespace Wincubate.Solid.Module01
{
    class StockAnalyzer
    {
        private readonly IReadStorage _readStorage;
        private readonly IWriteStorage _writeStorage;
        private readonly Parser _parser;
        private readonly ISerializer _serializer;

        public StockAnalyzer()
        {
            _readStorage = new WebStorage(@"http://solid.wincubate.net/stockpositions.json");
            //_writeStorage = new FileStorage( @"..\..\..\..\Files\StockPositions1.csv",@"..\..\..\..\Files\Result.json" );
            _writeStorage = new ConsoleStorage();
            //_storage = new FileStorage();
            //_parser = new Parser();
            _parser = new JsonParser();
            //_serializer = new CsvSerializer();
            _serializer = new JsonSerializer();
        }

        public void Process()
        {
            string inputDataAsString = _readStorage.GetDataAsString();
            IEnumerable<StockPosition> stockPositions = _parser.Parse(inputDataAsString);

            Computation computation = new Computation();
            IEnumerable<StockPosition> output = computation.Execute(stockPositions);

            string outputDataAsString = _serializer.SerializeData(output);

            _writeStorage.StoreDataAsString(outputDataAsString);
        }
    }
}
