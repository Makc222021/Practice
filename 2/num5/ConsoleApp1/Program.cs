using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Пример двумерного массива  
        int[,] array = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
            { -1, -2, -3 }
        };

        // Получаем новые отсортированные строки  
        var sortedRows = array.Cast<int>() // Складываем все элементы массива в одну последовательность  
            .Select((value, index) => new { Value = value, Row = index / array.GetLength(1) }) // Создаем анонимный тип с значением и номером строки  
            .GroupBy(x => x.Row) // Группируем по номеру строки  
            .Select(g => new
            {
                RowIndex = g.Key,
                Average = g.Average(x => x.Value),
                Values = g.Select(x => x.Value).ToArray()
            })
            .OrderBy(x => x.Average) // Сортируем по среднему значению  
            .Select(x => x.Values) // Получаем отсортированные значения  
            .ToArray();

        // Печатаем отсортированные строки  
        foreach (var row in sortedRows)
        {
            Console.WriteLine(string.Join(", ", row));
        }
    }
}