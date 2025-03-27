using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите целое число N (1 <= N <= 20):");
        int N = int.Parse(Console.ReadLine());

        if (N < 1 || N > 20)
        {
            Console.WriteLine("Некорректное значение N!");
            return;
        }

        double sum = 0;

        for (int i = 1; i <= N; i++)
        {
            sum += 1.0 / i;
        }

        Console.WriteLine($"Сумма ряда: {sum:F4}");
    }
}
