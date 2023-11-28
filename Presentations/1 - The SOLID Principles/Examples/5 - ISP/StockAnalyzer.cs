using Wincubate.Module1.Domain;

namespace Wincubate.Module1;

class StockAnalyzer
{
    private readonly IReadStorage _readStorage;
    private readonly IWriteStorage _writeStorage;
    private readonly IParser _parser;
    private readonly IFormatter _formatter;

    public StockAnalyzer()
    {
        _readStorage = new WebStorage(@"https://www.dotnet.coach/stockpositions.json");
        //_writeStorage = new FileStorage( @"..\..\..\..\Files\StockPositions1.csv",@"..\..\..\..\Files\Result.json" );
        _writeStorage = new ConsoleStorage();
        //_storage = new FileStorage();
        //_parser = new CsvParser();
        _parser = new JsonParser();
        //_formatter = new CsvFormatter();
        _formatter = new JsonFormatter();
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
