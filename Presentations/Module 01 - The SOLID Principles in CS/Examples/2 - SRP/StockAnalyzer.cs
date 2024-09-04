using Wincubate.Module1.Domain;

namespace Wincubate.Module1;

class StockAnalyzer
{
    private readonly FileStorage _storage;
    private readonly CsvParser _parser;
    private readonly CsvFormatter _formatter;

    public StockAnalyzer()
    {
        _storage = new FileStorage();
        _parser = new CsvParser();
        _formatter = new CsvFormatter();
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
