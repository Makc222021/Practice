using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество чисел n:");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите числа через пробел:");
        int[] numbers = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int oddCount = 0;

        foreach (int num in numbers)
        {
            if (num % 2 != 0)
            {
                oddCount++;
            }
        }

        Console.WriteLine($"Количество нечетных чисел: {oddCount}");
    }
}
