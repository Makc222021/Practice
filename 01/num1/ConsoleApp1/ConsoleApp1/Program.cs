using System;

class Program
{
    static void Main()
    {
        const double a = 3.23;
        const double b = 4.54;
        double x;

        x = (a + b) / 2.0; // Вычисление полусуммы значений a и b

        // Округление до трех знаков после запятой
        x = Math.Round(x, 3);

        Console.WriteLine("a = 3.23, b = 4.54;");
        Console.WriteLine($"Полусумма значений a и b равна: {x}");
        
        Console.ReadLine(); // Чтобы консольное окно не закрывалось сразу
    }
}