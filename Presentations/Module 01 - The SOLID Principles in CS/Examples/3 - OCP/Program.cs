using Wincubate.Module1;

string sourceFilePath = @"..\..\..\..\Files\StockPositions2.json";
string destinationFilePath = @"..\..\..\..\Files\Result.json";

try
{
    StockAnalyzer analyzer = new();
    await analyzer.ProcessAsync(sourceFilePath, destinationFilePath);
}
catch (StockException exception)
{
    Console.WriteLine($"Unexpected error occurred: {exception.Message}");
}
