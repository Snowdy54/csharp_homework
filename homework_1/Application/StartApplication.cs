namespace ConsoleApp1.Application;
using Domain;
using System.Collections.Generic;

public class StartApplication
{
    private readonly IFilePathGetter _filePathGetter;
    private string _filePath;
    private List<Client> _clients;
    private List<OrderReport> _reports;
    private readonly IDataReader _dataReader;
    private readonly IDataSort _dataSort;
    private readonly IPrinter _printer;
    private readonly IDataInput _dataInput;
    
    public StartApplication(IDataReader dataReader,
        IDataSort dataSort, IPrinter printer, IFilePathGetter filePathGetter, IDataInput inputData)
    {
        _dataReader = dataReader;
        _dataSort = dataSort;
        _printer = printer;
        _filePathGetter = filePathGetter;
        _dataInput = inputData;
    }

    public void Run()
    {
        GetFilePath(_filePathGetter);
        ReadData(_dataReader);
        SortData(_dataSort,  _dataInput);
        Print(_printer);
    }

    private void GetFilePath(IFilePathGetter filePath)
    {
        _filePath = filePath.GetFilePath();
    }

    private void ReadData(IDataReader dataReader)
    {
        _clients = dataReader.Read(_filePath);
    }

    private void SortData(IDataSort dataSort, IDataInput dataInput)
    {
        _reports = dataSort.Sort(_clients, dataInput);
    }

    private void Print(IPrinter printer)
    {
        printer.Print(_reports);
    }
}
