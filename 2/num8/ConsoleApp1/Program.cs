using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите первую строку:");
        string str1 = Console.ReadLine();

        Console.WriteLine("Введите вторую строку:");
        string str2 = Console.ReadLine();

        bool isPermutation = IsPermutation(str1, str2);

        if (isPermutation)
            Console.WriteLine("Одна строка является перестановкой другой.");
        else
            Console.WriteLine("Одна строка не является перестановкой другой.");
    }

    static bool IsPermutation(string str1, string str2)
    {
        if (str1.Length != str2.Length)
            return false;

        int[] charCounts = new int[256]; // ASCII таблица

        foreach (char c in str1)
            charCounts[c]++;

        foreach (char c in str2)
        {
            charCounts[c]--;
            if (charCounts[c] < 0)
                return false;
        }

        return true;
    }
}
