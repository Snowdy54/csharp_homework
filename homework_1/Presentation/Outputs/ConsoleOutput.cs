namespace ConsoleApp1.Presentation;

using Application;
using Domain;

internal class ConsoleOutput: IPrinter
{
    public void Print(List<OrderReport> reports)
    {
        foreach (var item in reports)
        {
            Console.WriteLine("| client_id" + " | orders_sum" + " | favourite_item_name |");
            Console.WriteLine($"{item.ClientId}        | {item.OrderSum:F2}   |    {item.FavoriteItemName}");
        }
    }
}