using System;

class Program
{
    // Метод для вычисления z1
    static double? CalculateZ1(double alpha)
    {
        double numerator = Math.Sin(2 * alpha) + Math.Sin(5 * alpha) - Math.Sin(3 * alpha);
        double denominator = Math.Cos(alpha) - Math.Cos(3 * alpha) + Math.Cos(5 * alpha);

        if (denominator == 0)
        {
            return null; // Предотвращение деления на ноль
        }

        return numerator / denominator;
    }

    // Метод для вычисления z2
    static double CalculateZ2(double alpha)
    {
        return Math.Tan(3 * alpha);
    }

    static void Main(string[] args)
    {
        // Тестовые примеры углов в радианах
        double[] testAngles = { 0.1, 0.5, 1.0, 1.5, 2.0 };

        // Вывод заголовка таблицы
        Console.WriteLine("α (радианы) | z1             | z2             | Разница");
        Console.WriteLine("---------------------------------------------------------");

        // Цикл для вычисления и вывода значений
        foreach (double alpha in testAngles)
        {
            double? z1 = CalculateZ1(alpha);
            double z2 = CalculateZ2(alpha);

            if (z1 == null)
            {
                Console.WriteLine($"{alpha:F2}         | Деление на ноль | {z2:F10} | -");
            }
            else
            {
                double difference = Math.Abs(z1.Value - z2);
                Console.WriteLine($"{alpha:F2}         | {z1.Value:F10} | {z2:F10} | {difference:F10}");
            }
        }
    }
}