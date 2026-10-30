using ConsoleApp1.Domain;

namespace ConsoleApp1.Application;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<StartApplication>();

       return services;
    }
}