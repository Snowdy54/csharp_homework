namespace ConsoleApp1.Domain;

public class OrderReport
{
    public long ClientId { get; }
    public float OrderSum { get; }
    public int ItemQuantity { get; }
    public string FavoriteItemName { get; }

    public OrderReport(
        long clientId,
        float orderSum,
        int orderCount,
        string favoriteItemName)
    {
        ClientId = clientId;
        OrderSum = orderSum;
        ItemQuantity = orderCount;
        FavoriteItemName = favoriteItemName;
    }
}


