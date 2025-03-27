using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите первую строку:");
        string str1 = Console.ReadLine();

        Console.WriteLine("Введите вторую строку:");
        string str2 = Console.ReadLine();

        bool areAnagrams = AreAnagrams(str1, str2);

        if (areAnagrams)
            Console.WriteLine("Строки являются анаграммами.");
        else
            Console.WriteLine("Строки не являются анаграммами.");
    }

    static bool AreAnagrams(string str1, string str2)
    {
        if (str1.Length != str2.Length)
            return false;

        char[] arr1 = str1.ToLower().ToCharArray();
        char[] arr2 = str2.ToLower().ToCharArray();

        Array.Sort(arr1);
        Array.Sort(arr2);

        return new string(arr1) == new string(arr2);
    }
}
