using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество строк и столбцов матрицы:");
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rows, cols];
        Console.WriteLine("Введите элементы матрицы построчно:");

        for (int i = 0; i < rows; i++)
        {
            string[] rowElements = Console.ReadLine().Split();
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = int.Parse(rowElements[j]);
            }
        }

        // Сумма квадратов положительных чисел
        int positiveSquareSum = 0;

        // Сумма элементов каждой строки
        for (int i = 0; i < rows; i++)
        {
            int rowSum = 0;
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] > 0)
                {
                    positiveSquareSum += matrix[i, j] * matrix[i, j];
                }
                rowSum += matrix[i, j];
            }
            Console.WriteLine($"Сумма элементов строки {i + 1}: {rowSum}");
        }

        Console.WriteLine($"Сумма квадратов положительных чисел: {positiveSquareSum}");
    }
}
