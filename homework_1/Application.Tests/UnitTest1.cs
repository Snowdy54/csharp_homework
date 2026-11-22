using ConsoleApp1.Application;
using ConsoleApp1.Infrastructure;
using ConsoleApp1.Domain;

namespace Application.Tests;

public class UnitTest1
{
    internal class DataSort : IDataSort
    {
        public List<OrderReport> Sort(List<Client> data, IDataInput input)
        {
            var orderReports = new List<OrderReport>();

            var report = data.GroupBy(x => x.ClientId).Select(orders =>
                new
                {
                    ClientId = orders.Key,
                    OrderSum = orders.Sum(order => order.ItemPrice * order.ItemQuantity),
                    ItemQuantity = orders.Sum(order => order.ItemQuantity),
                    FavouriteItemName = orders.GroupBy(order => order.OrderName).OrderByDescending(group
                        => group.Sum(order => order.ItemQuantity)).First().Key
                }).ToList();
        
            if (input.ClientIds[0] != "")
            {
                var clients = input.ClientIds.Select(x => long.Parse(x)).ToList();
                report = report.Where(x => clients.Contains(x.ClientId)).ToList();
            }
        
            foreach (var item in report)
            {
                var clientId = item.ClientId;
                var orderSum = item.OrderSum;
                var itemQuantity = item.ItemQuantity;
                var favouriteItemName = item.FavouriteItemName;
                var clientReport = new OrderReport(clientId, orderSum, itemQuantity, favouriteItemName);
                orderReports.Add(clientReport);
            }
        
            return orderReports;
        }
    }
    [Fact]
    public void CheckDataSort()
    {
        List<Client> clients = [new ("1010","1", "Огурчики", "1", "100"),
            new ("1010", "1", "Чипсы", "4", "100"),
        new ("1010", "4", "Огурчики", "1", "100")];

        List<OrderReport> correctReport = [new OrderReport(1010, 600, 6, "Чипсы")];
        string[] userList = { "1010" }; 
        var dataInput = new InputData("console", userList);
        var datSort = new DataSort();
        var sortedData = datSort.Sort(clients, dataInput);
        
        Assert.Equal(sortedData, correctReport);
    }
}
