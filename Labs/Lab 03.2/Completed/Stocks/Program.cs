using Wincubate.Module1;
using Wincubate.Module1.Exceptions;

using var diConfig = new DiConfig();

try
{
    StockAnalyzer analyzer = diConfig.Resolve<StockAnalyzer>();
    await analyzer.ProcessAsync();
}
catch (StockException exception)
{
    Console.WriteLine($"Unexpected error occurred: {exception.Message}");
}
