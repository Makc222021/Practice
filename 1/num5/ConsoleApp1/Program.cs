using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите трехзначное число:");
        int number = int.Parse(Console.ReadLine());

        if (number < 100 || number > 999)
        {
            Console.WriteLine("Это не трехзначное число!");
            return;
        }

        int firstDigit = number / 100; // Первая цифра
        int secondDigit = (number / 10) % 10; // Вторая цифра

        if (firstDigit > secondDigit)
        {
            Console.WriteLine("Первая цифра больше второй.");
        }
        else if (secondDigit > firstDigit)
        {
            Console.WriteLine("Вторая цифра больше первой.");
        }
        else
        {
            Console.WriteLine("Первая и вторая цифры равны.");
        }
    }
}
