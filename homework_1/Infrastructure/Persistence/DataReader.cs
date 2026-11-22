namespace ConsoleApp1.Infrastructure;

using Application;
using Domain;

internal class DataReader: IDataReader
{
    public List<Client> Read(string filePath)
    {
        string[] lines;
        try
        {
            lines = File.ReadAllLines(filePath);
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("Файл не найден. Файл должен находиться в корне проекта sln");
            throw new FileNotFoundException();
        }
        catch (IOException ex)
        {
            throw new IOException($"Не удалось прочитать файл: {ex.Message}");
        }
        
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