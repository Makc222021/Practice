using System;

class Program
{
    static void Main(string[] args)
    {
        string input = "abk"; // Ваша строка  
        Console.WriteLine("Перестановки строки: ");
        Permute(input, 0, input.Length - 1);
    }

    static void Permute(string str, int left, int right)
    {
        if (left == right)
        {
            Console.WriteLine(str);
        }
        else
        {
            for (int i = left; i <= right; i++)
            {
                str = Swap(str, left, i); // Меняем местами  
                Permute(str, left + 1, right); // Рекурсивно вызываем метод  
                str = Swap(str, left, i); // Возвращаем обратно  
            }
        }
    }

    static string Swap(string str, int i, int j)
    {
        char temp;
        char[] charArray = str.ToCharArray();
        temp = charArray[i];
        charArray[i] = charArray[j];
        charArray[j] = temp;
        return new string(charArray);
    }
}