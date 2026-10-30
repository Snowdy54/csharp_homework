using System.Collections;
using System.Data;
using ConsoleApp1.Application;
using IDataReader = ConsoleApp1.Application.IDataReader;

namespace ConsoleApp1.Infrastracture;

using Domain;

class Program
{

    private static void Main()
    {
    }
}

public class DataReader: IDataReader
{
    public List<Client> Read(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var data = new List<Client>();

        for (var i = 1; i < lines.Length; i++)
        {
            var columns = lines[i].Split(',');
            var clientId = columns[0];
            var orderId = columns[1];
            var orderName = columns[2];
            var itemQuantity = columns[3];
            var itemPrice = columns[4];

            var client = new Client(clientId, orderId, orderName, itemQuantity, itemPrice);
            data.Add(client);
        }

        return data;
    }
}

class DataSort : IDataSort
{
    public List<OrderReport> Sort(List<Client> data)
    {
        var orderReports = new List<OrderReport>();
        
        var report = data.GroupBy(x => x.ClientId).Select(orders =>
            new
            {
                ClientId = orders.Key,
                OrderSum = orders.Sum(order => order.ItemPrice),
                ItemQuantity = orders.Sum(order => order.ItemQuantity),
                FavouriteItemName = orders.GroupBy(order => order.OrderName).Select(orderGroup => new
                {
                    ItemsCount = orderGroup.Count()
                }).OrderByDescending(orderGroup => orderGroup.ItemsCount)
                    .FirstOrDefault()
            }).ToList();
        
        foreach (var item in report)
        {
            var clientId = item.ClientId;
            var orderSum = item.OrderSum;
            var itemQuantity = item.ItemQuantity;
            var favouriteItemName = item.FavouriteItemName?.ToString();
            var clientReport = new OrderReport(clientId, orderSum, itemQuantity, favouriteItemName);
            orderReports.Add(clientReport);
        }
        
        return orderReports;
    }
}

class ConsoleOutput: IPrinter
{
    public void Print(List<OrderReport> reports)
    {
        foreach (var item in reports)
        {
            Console.WriteLine("| client_id" + " | orders_sum" + " | favourite_item_name |");
            Console.WriteLine($"{item.ClientId}  | {item.OrderSum} | {item.FavoriteItemName}");
        }
    }
}
