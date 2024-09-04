using Wincubate.Module1;
using Wincubate.Module1.Domain;

try
{
    string sourceFilePath = @"..\..\..\..\Files\StockPositions1.csv";
    string inputDataAsString = await GetDataAsStringAsync(sourceFilePath);

    IEnumerable<StockPosition> stockPositions = Parse(inputDataAsString);

    IEnumerable<StockPosition> output = Execute(stockPositions);

    string outputDataAsString = FormatData(output);

    string destinationFilePath = @"..\..\..\..\Files\Result.csv";
    await StoreDataAsStringAsync(destinationFilePath, outputDataAsString);
}
catch(StockException exception)
{
    Console.WriteLine($"Unexpected error occurred: {exception.Message}");
}

static Task<string> GetDataAsStringAsync(string sourceFilePath)
{
    return File.ReadAllTextAsync(sourceFilePath);
}

static Task StoreDataAsStringAsync(
    string destinationFilePath,
    string outputDataAsString)
{
    return File.WriteAllTextAsync(destinationFilePath, outputDataAsString);
}

static IEnumerable<StockPosition> Parse(string dataAsString)
{
    try
    {
        return dataAsString
            .Split('\n', '\r', '\t')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(line => line.Split(','))
            .Select(parts => new StockPosition(
                parts[0],
                int.Parse(parts[1]))
            )
            .ToList()
            ;
    }
    catch (Exception exception)
    {
        string message = $"Could not parse CSV string: \"{dataAsString}\"";
        throw new StockException(message, exception);
    }
}

static IEnumerable<StockPosition> Execute(IEnumerable<StockPosition> inputData)
{
    return inputData
        .GroupBy(stockPosition => stockPosition.Ticker)
        .Select(group => new StockPosition(
            group.Key,
            group.Sum(stockPosition => stockPosition.Size))
        )
        .ToList()
        ;
}

static string FormatData(IEnumerable<StockPosition> outputData)
{
    IEnumerable<string> outputLines = outputData
        .Select(stockPosition => $"{stockPosition.Ticker},{stockPosition.Size}")
        ;
    return string.Join(Environment.NewLine, outputLines);
}

