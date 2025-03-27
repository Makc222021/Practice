using System;

class Program
{
    static void Main(string[] args)
    {
        // Ввод значения x
        Console.Write("Введите значение x: ");
        double x = double.Parse(Console.ReadLine());

        // Переменная для результата y
        double y;

        // Вычисление y по заданным условиям
        if (x > 2)
        {
            y = Math.Pow(x, 3) * Math.Sqrt(x - 2);
        }
        else if (x == 2)
        {
            y = x * Math.Sin(2 * x);
        }
        else // x < 2
        {
            y = Math.Exp(-2 * x) * Math.Cos(2 * x);
        }

        // Вывод результата
        Console.WriteLine($"Значение y: {y:F4}");
    }
}