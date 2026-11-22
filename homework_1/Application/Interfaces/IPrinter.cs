using ConsoleApp1.Domain;

namespace ConsoleApp1.Application;

public interface IPrinter
{
    void Print(List<OrderReport> reports);
}