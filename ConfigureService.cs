using System.Reflection;

using Microsoft.Extensions.DependencyInjection;
using NewService.API.Service;

namespace NewService;

public static class ConfigureService
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        Console.WriteLine("OK");
        Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<BackGroundService>();
                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
                // Добавьте другие сервисы и конфигурации, если необходимо
            })
            .RunConsoleAsync();
        
        return services;
    }
}