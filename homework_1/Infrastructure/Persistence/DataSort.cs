namespace ConsoleApp1.Infrastructure;

using Application;
using Domain;

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