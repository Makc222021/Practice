using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите четырехзначное число:");
        int number = Convert.ToInt32(Console.ReadLine());

        // Проверка на четырехзначность числа
        if (number < 1000 || number > 9999)
        {
            Console.WriteLine("Пожалуйста, введите четырехзначное число.");
        }
        else
        {
            // Получаем первые две цифры
            int firstTwoDigits = number / 100;

            // Получаем последние две цифры
            int lastTwoDigits = number % 100;

            // Формируем число с переставленными первыми двумя цифрами
            int newNumber = lastTwoDigits * 100 + firstTwoDigits;

            Console.WriteLine($"Число, образуемое при перестановке двух первых цифр: {newNumber}");
        }

        Console.ReadLine(); // Чтобы консольное окно не закрывалось сразу
    }
}