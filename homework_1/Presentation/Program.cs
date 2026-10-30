using System.Data;
using ConsoleApp1.Application;
using ConsoleApp1.Infrastracture;
using Microsoft.Extensions.DependencyInjection;


namespace ConsoleApp1.Presentation;


class Program
{

    private static void Main()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddApplication();
        serviceCollection.AddInfrastracture();
        
        var provider  = serviceCollection.BuildServiceProvider();

        var application = provider.GetRequiredService<StartApplication>();
        var filePath = @"D:\Programming\.NET\ConsoleApp1\orders_log.csv";
        
        application.Run(filePath);
    }
}