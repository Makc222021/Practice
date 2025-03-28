using System;

namespace DataAnalysisExample
{
    // Объявление делегата DataAnalyzer
    delegate void DataAnalyzer(int[] data);

    class Program
    {
        // Метод для анализа данных
        static void AnalyzeData(int[] data, DataAnalyzer analyzer)
        {
            // Выполнение переданного делегата
            analyzer(data);
        }

        // Метод для расчета среднего значения
        static void CalculateAverage(int[] data)
        {
            if (data.Length == 0)
            {
                Console.WriteLine("Массив пуст. Невозможно вычислить среднее значение.");
                return;
            }
            double average = 0;
            foreach (var num in data)
            {
                average += num;
            }
            average /= data.Length;
            Console.WriteLine($"Среднее значение: {average:F2}");
        }

        // Метод для нахождения максимального значения
        static void FindMaximum(int[] data)
        {
            if (data.Length == 0)
            {
                Console.WriteLine("Массив пуст. Невозможно найти максимальное значение.");
                return;
            }
            int max = data[0];
            foreach (var num in data)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            Console.WriteLine($"Максимальное значение: {max}");
        }

        static void Main(string[] args)
        {
            // Пример массива данных
            int[] data = { 5, 8, 2, 10, 3, 7 };

            // Вызов метода AnalyzeData с разными делегатами
            Console.WriteLine("Анализ данных: ");

            // Передаем метод CalculateAverage
            Console.WriteLine("\n1. Вычисление среднего значения:");
            AnalyzeData(data, CalculateAverage);

            // Передаем метод FindMaximum
            Console.WriteLine("\n2. Нахождение максимального значения:");
            AnalyzeData(data, FindMaximum);
        }
    }
}