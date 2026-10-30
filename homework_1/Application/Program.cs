namespace ConsoleApp1.Application;
using Domain;
using System.Collections.Generic;
class Program

{
    private static void Main()
    {
    }
}

public interface IDataReader
{
    List<Client> Read(string filePath);
}

public interface IDataSort
{
    List<OrderReport> Sort(List<Client> data);
}

public interface IPrinter
{
    void Print(List<OrderReport> reports);
}


public class StartApplication
{
    private string _filePath;
    private List<Client> _clients;
    private List<OrderReport> _reports;
    private readonly IDataReader _dataReader;
    private readonly IDataSort _dataSort;
    private readonly IPrinter _printer;
    
    public StartApplication(IDataReader dataReader,
        IDataSort dataSort, IPrinter printer)
    {
        _dataReader = dataReader;
        _dataSort = dataSort;
        _printer = printer;
    }

    public void Run(string filePath)
    {
        _filePath = filePath;
        ReadData(_dataReader);
        SortData(_dataSort);
        Print(_printer);
    }

    private void ReadData(IDataReader dataReader)
    {
        _clients = dataReader.Read(_filePath);
    }

    private void SortData(IDataSort dataSort)
    {
        _reports = dataSort.Sort(_clients);
    }

    private void Print(IPrinter printer)
    {
        printer.Print(_reports);
    }
}
