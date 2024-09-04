using Microsoft.Extensions.DependencyInjection;
using Wincubate.Module1;

internal class DiConfig : IDisposable
{
    private readonly ServiceProvider _container;
    private readonly IServiceScope _scope;

    public DiConfig()
    {
        var services = Register();
        _container = services.BuildServiceProvider(true);
        _scope = _container.CreateScope();
    }

    private IServiceCollection Register()
    {
        IServiceCollection services = new ServiceCollection();
        services
            .AddSingleton<IWriteStorage, ConsoleStorage>()
            .AddTransient<IParser, JsonParser>()
            .AddTransient<IFormatter, JsonFormatter>()
            .AddSingleton<IReadStorage>(sp => new WebStorage(@"https://www.dotnet.coach/stockpositions.json"))
            .AddTransient<StockAnalyzer>()
            ;
        return services;
    }

    public T Resolve<T>() where T : notnull
        => _scope.ServiceProvider.GetRequiredService<T>();

    public void Dispose()
    {
        _container.Dispose();
    }
}
