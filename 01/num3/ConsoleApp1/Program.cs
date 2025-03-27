using System;

class Program
{
    static void Main()
    {
        double x = 5.2; // Заданное значение аргумента
        double y = Math.Pow(Math.Sin(Math.Pow(x, 2) + 5), 3) - Math.Sqrt(x / 4);

        Console.WriteLine($"Значение функции y = sin^3(x^2 + 5)^2 - √(x/4) при x = {x}: {y}");
    }
}