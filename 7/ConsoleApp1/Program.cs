using System;

namespace CustomExceptionExample
{
    // Класс пользовательского исключения
    public class OverweightLuggageException : Exception
    {
        // Конструктор по умолчанию
        public OverweightLuggageException() : base("Вес багажа превышает допустимый лимит в 23 кг.")
        {
        }

        // Конструктор с сообщением
        public OverweightLuggageException(string message) : base(message)
        {
        }

        // Конструктор с сообщением и внутренним исключением
        public OverweightLuggageException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    // Класс Luggage с методом проверки веса
    public class Luggage
    {
        // Метод проверки веса багажа
        public void CheckWeight(int weight)
        {
            if (weight > 23)
            {
                throw new OverweightLuggageException($"Вес вашего багажа ({weight} кг) превышает допустимый лимит в 23 кг.");
            }

            Console.WriteLine($"Вес багажа ({weight} кг) в пределах допустимого.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем объект класса Luggage
            Luggage luggage = new Luggage();

            // Массив с примерами веса багажа
            int[] weights = { 18, 23, 25 };

            foreach (var weight in weights)
            {
                try
                {
                    Console.WriteLine($"Проверка багажа с весом {weight} кг...");
                    luggage.CheckWeight(weight); // Проверяем вес багажа
                }
                catch (OverweightLuggageException ex)
                {
                    // Обрабатываем пользовательское исключение
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Проверка завершена.\n");
                }
            }
        }
    }
}