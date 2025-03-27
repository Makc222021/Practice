using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку:");
        string input = Console.ReadLine();

        Dictionary<char, int> charCount = new Dictionary<char, int>();

        foreach (char c in input)
        {
            if (charCount.ContainsKey(c))
                charCount[c]++;
            else
                charCount[c] = 1;
        }

        char mostFrequentChar = '\0';
        int maxCount = 0;

        foreach (var pair in charCount)
        {
            if (pair.Value > maxCount)
            {
                mostFrequentChar = pair.Key;
                maxCount = pair.Value;
            }
        }

        Console.WriteLine($"Символ, который встречается чаще всего: '{mostFrequentChar}' ({maxCount} раз)");
    }
}
