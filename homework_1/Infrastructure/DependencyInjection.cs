using ConsoleApp1.Application;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp1.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IDataReader, DataReader>();
        services.AddSingleton<IDataSort, DataSort>();
        services.AddSingleton<IFilePathGetter, FilePathChecker>();
        return services;
    }
}