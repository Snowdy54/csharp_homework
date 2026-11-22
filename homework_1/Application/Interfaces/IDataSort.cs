using ConsoleApp1.Domain;

namespace ConsoleApp1.Application;

public interface IDataSort
{
    List<OrderReport> Sort(List<Client> data, IDataInput input);
}