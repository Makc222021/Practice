using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите элементы массива через пробел:");
        int[] numbers = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int sum = 0, count = 0;

        foreach (int num in numbers)
        {
            if (num % 5 == 0)
            {
                sum += num;
                count++;
            }
        }

        if (count > 0)
        {
            double average = (double)sum / count;
            Console.WriteLine($"Среднее арифметическое элементов, кратных 5: {average:F2}");
        }
        else
        {
            Console.WriteLine("Нет элементов, кратных 5.");
        }
    }
}
