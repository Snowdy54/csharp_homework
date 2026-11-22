using ConsoleApp1.Application;

internal class UserInput
{
    private static string ReportType;
    private static string[] ClientIds;
    public static InputData Input()
    {
        Console.WriteLine("Выберите тип отчёта.");
        Console.WriteLine("Введите 'console' для вывода отчёта в консоль");
        Console.WriteLine("Введите 'file' для вывода отчёта в файл");
        while (true)
        {
            Console.WriteLine("Ввод: ");
            ReportType = Console.ReadLine();
            if (ReportType != "console" && ReportType != "file")
            {
                Console.WriteLine("Ошибка при вводе типа отчёта! Укажите 'file' или 'console'");
                continue;
            }
            break;
        }
        Console.WriteLine("Необходим ли отчёт по конкретным пользователям?");
        Console.WriteLine("Если да, то введите id клиентов. Иначе просто оставьте пустое поле");
        while (true)
        {
            Console.WriteLine("Ввод: ");
            ClientIds = Console.ReadLine().Trim().Split(" ");
            foreach (var clientId in ClientIds)
            {
                try
                {
                    if (clientId != "")
                    {
                        if (long.Parse(clientId) <= 0)
                        {
                            Console.WriteLine("Ошибка ввода! Id должен быть больше 0!");
                        }
                    }
                    
                }
                catch (FormatException)
                {
                    Console.Error.WriteLine("Id указан в неверном формате! Необходимый формат - long");
                    break;
                }
                catch (OverflowException)
                {
                    Console.Error.WriteLine("Id указан в неверном формате. Слишком большое или маленькое значение!");
                    break;
                }
            }
            break;
        }
        return new InputData(ReportType, ClientIds);
    }
}