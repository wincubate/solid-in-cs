using Wincubate.Module1.Domain;

namespace Wincubate.Module1;

class StockAnalyzer
{
    private readonly IStorage _storage;
    private readonly IParser _parser;
    private readonly IFormatter _formatter;

    public StockAnalyzer()
    {
        _storage = new FileStorage();
        //_parser = new CsvParser();
        _parser = new JsonParser();
        //_formatter = new CsvFormatter();
        _formatter = new JsonFormatter();
    }

    public async Task ProcessAsync(string sourceFilePath, string destinationFilePath)
    {
        string inputDataAsString = await _storage.GetDataAsStringAsync(sourceFilePath);
        IEnumerable<StockPosition> stockPositions = _parser.Parse(inputDataAsString);

        Computation computation = new Computation();
        IEnumerable<StockPosition> output = computation.Execute(stockPositions);

        string outputDataAsString = _formatter.FormatData(output);

        await _storage.StoreDataAsStringAsync(destinationFilePath, outputDataAsString);
    }
}
