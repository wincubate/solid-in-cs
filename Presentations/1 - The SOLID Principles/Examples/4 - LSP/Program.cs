namespace Wincubate.Module1;

static class Program
{
    static async Task Main(string[] args)
    {
        string sourceFilePath = @"..\..\..\..\Files\StockPositions2.json";
        string destinationFilePath = @"..\..\..\..\Files\Result.json";

        StockAnalyzer analyzer = new();
        await analyzer.ProcessAsync(sourceFilePath, destinationFilePath);
    }
}
