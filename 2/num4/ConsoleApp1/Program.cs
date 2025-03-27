using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите элементы массива через пробел:");
        int[] numbers = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        double average = 0;

        foreach (int num in numbers)
            average += num;

        average /= numbers.Length;

        double minDifference = double.MaxValue;
        int closestIndex = -1;

        for (int i = 0; i < numbers.Length; i++)
        {
            double diff = Math.Abs(numbers[i] - average);
            if (diff < minDifference)
            {
                minDifference = diff;
                closestIndex = i;
            }
        }

        Console.WriteLine($"Среднее значение: {average:F2}");
        Console.WriteLine($"Элемент, ближайший к среднему: {numbers[closestIndex]} (индекс {closestIndex})");

        // Проверка на четырехзначность суммы
        int sum = 0;

        foreach (int num in numbers)
            sum += num;

        if (sum >= 1000 && sum <= 9999)
            Console.WriteLine("Сумма элементов является четырехзначным числом.");
        else
            Console.WriteLine("Сумма элементов не является четырехзначным числом.");
    }
}
