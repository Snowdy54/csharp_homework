using ConsoleApp1.Application;

namespace ConsoleApp1.Infrastructure;

internal class FilePathChecker : IFilePathGetter
{
    public string GetFilePath()
    { 
        return Path.Combine(AppContext.BaseDirectory, "orders_log.csv");
    }
}