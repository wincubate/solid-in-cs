//string sourceFilePath = @"..\..\..\..\Files\StockPositions1.csv";
//string sourceFilePath = @"..\..\..\..\Files\StockPositions2.json";
//string sourceFilePath = @"https://www.dotnet.coach/stockpositions.json";
//string destinationFilePath = @"..\..\..\..\Files\Result.csv";
//string destinationFilePath = @"..\..\..\..\Files\Result.json";

using Wincubate.Module1;

try
{
    StockAnalyzer analyzer = new();
    await analyzer.ProcessAsync();
}
catch (StockException exception)
{
    Console.WriteLine($"Unexpected error occurred: {exception.Message}");
}
