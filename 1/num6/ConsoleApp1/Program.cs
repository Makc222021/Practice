using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите номер вагона (1-17):");
        int wagonNumber = int.Parse(Console.ReadLine());

        if (wagonNumber < 1 || wagonNumber > 17)
        {
            Console.WriteLine("Некорректный номер вагона!");
            return;
        }

        if (wagonNumber >= 10 && wagonNumber <= 17)
        {
            Console.WriteLine("Вагон купейный.");
        }
        else
        {
            Console.WriteLine("Вагон плацкартный.");
        }
    }
}
