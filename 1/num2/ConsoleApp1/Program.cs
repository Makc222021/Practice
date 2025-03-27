using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите трехзначное число: ");
        int number = int.Parse(Console.ReadLine());

        if (number < 100 || number > 999)
        {
            Console.WriteLine("Число должно быть трехзначным!");
            return;
        }

        // Разбиваем число на цифры
        int a = number / 100;       // Первая цифра
        int b = (number / 10) % 10; // Вторая цифра
        int c = number % 10;        // Третья цифра

        // Проверяем геометрическую прогрессию: b^2 == a * c
        if (b * b == a * c)
        {
            Console.WriteLine("Цифры числа образуют геометрическую прогрессию.");
        }
        else
        {
            Console.WriteLine("Цифры числа не образуют геометрическую прогрессию.");
        }
    }
}