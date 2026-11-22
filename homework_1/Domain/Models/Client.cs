using System.Globalization;

namespace ConsoleApp1.Domain;

public class Client
{
    public long ClientId { get; }
    public long OrderId { get; }
    public string OrderName { get; }
    public int ItemQuantity { get; }
    public float ItemPrice { get; }

    public Client(
        string clientId,
        string orderId,
        string orderName,
        string itemQuantity,
        string itemPrice)
    {
        if  (string.IsNullOrWhiteSpace(clientId))
            throw  new ArgumentException("Id клиента не может отсутствовать.");
        if (string.IsNullOrWhiteSpace(orderId))
            throw new ArgumentException("Id заказа не может отсутствовать.");
        if (string.IsNullOrWhiteSpace(orderName))
            throw new ArgumentException("Название заказа не может отсутствовать.");
        if (string.IsNullOrWhiteSpace(itemQuantity))
            throw new ArgumentException("Количество товара не может отсутствовать.");
        if (string.IsNullOrWhiteSpace(itemPrice))
            throw new ArgumentException("Цена товара не может отсутствовать.");
        
        ClientId =  long.Parse(clientId);
        OrderId = long.Parse(orderId);
        OrderName = orderName;
        ItemQuantity = int.Parse(itemQuantity);
        ItemPrice = float.Parse(itemPrice, CultureInfo.InvariantCulture);
    }
}