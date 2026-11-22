using ConsoleApp1.Application;
using ConsoleApp1.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using ConsoleApp1.Domain;

namespace ConsoleApp1.Presentation;

internal static class Program
{
    private static void Main()
    {
        var userInput = UserInput.Input();
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddPresentation(userInput);
        serviceCollection.AddApplication(userInput);
        serviceCollection.AddInfrastructure();
        
        var provider  = serviceCollection.BuildServiceProvider();

        var application = provider.GetRequiredService<StartApplication>();
        
        application.Run();
    }
}