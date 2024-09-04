using Microsoft.Extensions.DependencyInjection;

IServiceCollection services = new ServiceCollection();
services
    .AddSingleton<ISingletonish, Singletonish>()
    ;

var container = services.BuildServiceProvider(true);
var scope = container.CreateScope();

ISingletonish s1 = scope.ServiceProvider
    .GetRequiredService<ISingletonish>();
ISingletonish s2 = scope.ServiceProvider
    .GetRequiredService<ISingletonish>();

s1.DoStuff();
s2.DoStuff();

