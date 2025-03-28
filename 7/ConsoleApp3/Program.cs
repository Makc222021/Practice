using System;

namespace AccessControlExample
{
    // Определяем пользовательское исключение  
    public class AccessDeniedException : Exception
    {
        public AccessDeniedException(string message) : base(message) { }
    }

    // Класс для проверки времени доступа  
    public class AccessControl
    {
        public void CheckAccessTime(int hour)
        {
            if (hour < 9 || hour > 18)
            {
                throw new AccessDeniedException("Доступ запрещён. Время доступа должно быть между 9:00 и 18:00.");
            }
            Console.WriteLine("Доступ разрешён.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AccessControl accessControl = new AccessControl();

            Console.Write("Введите время доступа (час, 0-23): ");
            int hour;

            // Пытаемся считать введённое значение и обработать ошибки  
            try
            {
                hour = int.Parse(Console.ReadLine());
                accessControl.CheckAccessTime(hour);
            }
            catch (AccessDeniedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: некорректный ввод. Пожалуйста, введите число от 0 до 23.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла неожиданная ошибка: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}