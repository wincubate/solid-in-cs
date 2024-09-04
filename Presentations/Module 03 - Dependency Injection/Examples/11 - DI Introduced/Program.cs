using Microsoft.Extensions.DependencyInjection;
using Wincubate.Module1;

string Url = @"https://www.dotnet.coach/stockpositions.json";

IServiceCollection services = new ServiceCollection();
services
    .AddSingleton<IWriteStorage, ConsoleStorage>()
    .AddTransient<IParser, JsonParser>()
    .AddTransient<IFormatter, JsonFormatter>()
    .AddSingleton<IReadStorage>( sp => new WebStorage(Url) )
    .AddTransient<StockAnalyzer>()
    ;
using var serviceProvider = services.BuildServiceProvider(true);

try
{
    StockAnalyzer analyzer = serviceProvider.GetRequiredService<StockAnalyzer>();   
    await analyzer.ProcessAsync();
}
catch (StockException exception)
{
    Console.WriteLine($"Unexpected error occurred: {exception.Message}");
}
