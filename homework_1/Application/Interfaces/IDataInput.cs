namespace ConsoleApp1.Application;

public  interface IDataInput
{
    string ReportType { get; }
    string[] ClientIds { get; }
}