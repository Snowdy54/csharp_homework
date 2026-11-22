using ConsoleApp1.Application;
using ConsoleApp1.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp1.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, InputData input)
    {
        if (input.ReportType == "console")
        {
            services.AddSingleton<IPrinter, ConsoleOutput>();
        }
        else
        {
            services.AddSingleton<IPrinter, FileOutput>();
        }
        return services;
    }
}