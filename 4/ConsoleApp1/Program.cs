using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Пример входного массива
        int[] inputArray = { 1, 2, 2, 3, 4, 4, 5, 6, 6 };

        // Вызов статического метода для получения уникальных элементов
        int[] uniqueElements = GetUniqueElements(inputArray);

        // Вывод результата
        Console.WriteLine("Уникальные элементы:");
        foreach (int item in uniqueElements)
        {
            Console.WriteLine(item);
        }
    }

    // Статический метод для получения уникальных элементов
    public static T[] GetUniqueElements<T>(T[] inputArray)
    {
        // Используем HashSet для удаления дубликатов
        HashSet<T> uniqueSet = new HashSet<T>(inputArray);

        // Преобразуем HashSet обратно в массив
        T[] uniqueArray = uniqueSet.ToArray();

        return uniqueArray;
    }
}
