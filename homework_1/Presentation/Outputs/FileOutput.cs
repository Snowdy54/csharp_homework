using System.Text;
using ConsoleApp1.Application;
using ConsoleApp1.Domain;

internal class FileOutput : IPrinter
{
    public void Print(List<OrderReport> reports)
    {
        var mainText = "| client_id | orders_sum | favourite_item_name |";
        var splitter = "\n";
        
        File.AppendAllText("../../../../result.txt", mainText, Encoding.UTF8);
        File.AppendAllText("../../../../result.txt", splitter, Encoding.UTF8);
        foreach (var item in reports)
        {
            var text = $"{item.ClientId}        | {item.OrderSum:F2}   |    {item.FavoriteItemName}";
            File.AppendAllText("../../../../result.txt", text, Encoding.UTF8);
            File.AppendAllText("../../../../result.txt", splitter, Encoding.UTF8);
        }
    }
}