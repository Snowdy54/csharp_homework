namespace ConsoleApp1.Application;

using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, InputData input)
    {
        services.AddTransient<StartApplication>();
        services.AddSingleton<IDataInput>(input);
       return services;
    }
}