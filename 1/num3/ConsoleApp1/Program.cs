using System;

class Program
{
    static void Main(string[] args)
    {
        // Ввод вещественного числа A (-5 <= A <= 5)
        Console.Write("Введите вещественное число A (-5 <= A <= 5): ");
        double a = double.Parse(Console.ReadLine());

        if (a < -5 || a > 5)
        {
            Console.WriteLine("Число A должно быть в диапазоне от -5 до 5.");
            return;
        }

        // Ввод целого числа N (1 <= N <= 10)
        Console.Write("Введите целое число N (1 <= N <= 10): ");
        int n = int.Parse(Console.ReadLine());

        if (n < 1 || n > 10)
        {
            Console.WriteLine("Число N должно быть в диапазоне от 1 до 10.");
            return;
        }

        // Вывод степеней числа A от 1 до N
        Console.WriteLine($"Степени числа {a} от 1 до {n}:");
        double result = 1.0; // для хранения текущей степени
        for (int i = 1; i <= n; i++)
        {
            result *= a;
            Console.WriteLine($"A^{i} = {result:F4}");
        }
    }
}