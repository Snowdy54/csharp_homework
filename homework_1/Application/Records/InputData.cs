namespace ConsoleApp1.Application;

public record InputData(string ReportType, string[]  ClientIds) : IDataInput;