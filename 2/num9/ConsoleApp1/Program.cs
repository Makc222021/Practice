using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку:");
        StringBuilder sb = new StringBuilder(Console.ReadLine());

        for (int i = 0; i < sb.Length; i++)
            sb[i] = char.ToUpper(sb[i]);

        Console.WriteLine($"Преобразованная строка: {sb}");
    }
}
