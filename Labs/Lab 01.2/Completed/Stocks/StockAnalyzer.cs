using Wincubate.Module1.Domain;
using Wincubate.Module1.Formatters;
using Wincubate.Module1.Parsing;
using Wincubate.Module1.Storage;

namespace Wincubate.Module1;

class StockAnalyzer
{
    private readonly IReadStorage _readStorage;
    private readonly IWriteStorage _writeStorage;
    private readonly IParser _parser;
    private readonly IFormatter _formatter;

    public StockAnalyzer(
        IReadStorage readStorage,
        IWriteStorage writeStorage,
        IParser parser,
        IFormatter formatter
    )
    {
        _readStorage = readStorage;
        _writeStorage = writeStorage;
        _parser = parser;
        _formatter = formatter;
    }

    public async Task ProcessAsync()
    {
        string inputDataAsString = await _readStorage.GetDataAsStringAsync();
        IEnumerable<StockPosition> stockPositions = _parser.Parse(inputDataAsString);

        Computation computation = new Computation();
        IEnumerable<StockPosition> output = computation.Execute(stockPositions);

        string outputDataAsString = _formatter.FormatData(output);

        await _writeStorage.StoreDataAsStringAsync(outputDataAsString);
    }
}
