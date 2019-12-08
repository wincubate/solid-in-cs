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

        public StockAnalyzer(
            IReadStorage readStorage,
            IWriteStorage writeStorage,
            Parser parser,
            ISerializer serializer
        )
        {
            _readStorage = readStorage;
            _writeStorage = writeStorage;
            _parser = parser;
            _serializer = serializer;
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
