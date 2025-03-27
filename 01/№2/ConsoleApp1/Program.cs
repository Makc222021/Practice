using System;

class Program
{
    static void Main()
    {
        int number = 357; // Исходное трехзначное число

        // Находим первую цифру
        int firstDigit = number / 100;

        // Находим последнюю цифру
        int lastDigit = number % 10;

        // Находим сумму первой и последней цифр
        int sum = firstDigit + lastDigit;

        Console.WriteLine($"Сумма первой и последней цифр числа {number} равна: {sum}");
    }
}