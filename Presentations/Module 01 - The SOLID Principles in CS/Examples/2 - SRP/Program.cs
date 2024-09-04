using Wincubate.Module1;

string sourceFilePath = @"..\..\..\..\Files\StockPositions1.csv";
string destinationFilePath = @"..\..\..\..\Files\Result.csv";

try
{
    StockAnalyzer analyzer = new();
    await analyzer.ProcessAsync(sourceFilePath, destinationFilePath);
}
catch (StockException exception)
{
    Console.WriteLine($"Unexpected error occurred: {exception.Message}");
}
