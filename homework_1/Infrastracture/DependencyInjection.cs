using ConsoleApp1.Application;
using ConsoleApp1.Domain;

namespace ConsoleApp1.Infrastracture;

using Microsoft.Extensions.DependencyInjection;



public static class DependencyInjection
{
    public static IServiceCollection AddInfrastracture(this IServiceCollection services)
    {
        services.AddSingleton<IPrinter, ConsoleOutput>();
        services.AddSingleton<IDataReader, DataReader>();
        services.AddSingleton<IDataSort, DataSort>();
        return services;
    }
}