using ConsoleApp1.Domain;

namespace ConsoleApp1.Application;

public interface IDataReader
{
    List<Client> Read(string filePath);
}