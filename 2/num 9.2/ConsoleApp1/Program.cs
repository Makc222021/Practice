using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите время в формате чч:мм:");
        string time = Console.ReadLine();

        bool isValidTime = IsValidTime(time);

        if (isValidTime)
            Console.WriteLine("Строка является корректным временем.");
        else
            Console.WriteLine("Строка не является корректным временем.");
    }

    static bool IsValidTime(string time)
    {
        if (time.Length != 5 || time[2] != ':')
            return false;

        string[] parts = time.Split(':');

        if (!int.TryParse(parts[0], out int hours) || !int.TryParse(parts[1], out int minutes))
            return false;

        return hours >= 0 && hours <= 23 && minutes >= 0 && minutes <= 59;
    }
}
