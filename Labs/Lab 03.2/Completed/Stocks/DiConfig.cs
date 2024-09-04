using Microsoft.Extensions.DependencyInjection;
using Wincubate.Module1;
using Wincubate.Module1.Formatters;
using Wincubate.Module1.Parsing;
using Wincubate.Module1.Storage;
using Wincubate.Module1.Storage.Resilience;
using Wincubate.Module1.Storage.Sms;
using Wincubate.Module1.Storage.Web;

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
            .AddTransient<IParser, JsonParser>()
            .AddTransient<IFormatter, JsonFormatter>()
            .AddSingleton<IReadStorage>(
                sp => new WebStorage(@"https://www.dotnet.coach/stockpositions.json")
            )
            .AddSingleton<IWriteStorage, ConsoleStorage>()
            .AddSingleton<IWriteStorage, TwilioSmsWriteStorage>(
                sp => new TwilioSmsWriteStorage("+4512345678")
            )
            .AddKeyedTransient<IWriteStorage, CompositeWriteStorage>("composite")
            .AddKeyedTransient<IWriteStorage, RetryingWriteStorageProxy>("retry")
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
