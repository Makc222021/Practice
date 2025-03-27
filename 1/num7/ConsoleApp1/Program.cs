using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Трехзначные числа с двумя одинаковыми цифрами:");

        for (int number = 100; number <= 999; number++)
        {
            int firstDigit = number / 100;
            int secondDigit = (number / 10) % 10;
            int thirdDigit = number % 10;

            if (firstDigit == secondDigit || firstDigit == thirdDigit || secondDigit == thirdDigit)
            {
                Console.WriteLine(number);
            }
        }
    }
}
