using System;
using System.IO;

namespace ExceptionHandlingExample
{
    // Класс для работы с безопасным файлом
    public class FileSecurity
    {
        // Метод для открытия защищенного файла
        public void OpenSecureFile(string path)
        {
            try
            {
                // Искусственно выбрасываем UnauthorizedAccessException для демонстрации
                throw new UnauthorizedAccessException("Доступ к файлу запрещен.");
            }
            catch (UnauthorizedAccessException ex)
            {
                // Логируем ошибку и пробрасываем ее дальше
                Console.WriteLine($"[FileSecurity] Ошибка: {ex.Message}");
                throw;
            }
        }
    }

    // Класс для управления доступом к файлам
    public class FileAccessManager
    {
        private readonly FileSecurity _fileSecurity = new FileSecurity();

        // Метод проверки доступа к файлу
        public void AccessFile(string path)
        {
            try
            {
                // Попытка открыть защищенный файл
                _fileSecurity.OpenSecureFile(path);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Перехватываем исключение и оборачиваем его в SecurityException
                throw new SecurityException("Ошибка при доступе к защищенному файлу.", ex);
            }
        }
    }

    // Пользовательское исключение SecurityException
    public class SecurityException : Exception
    {
        public SecurityException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем объект FileAccessManager
            FileAccessManager fileAccessManager = new FileAccessManager();

            try
            {
                // Попытка доступа к файлу
                Console.WriteLine("Попытка открыть файл...");
                fileAccessManager.AccessFile("secure_file.txt");
            }
            catch (SecurityException ex)
            {
                // Логируем исключение, включая данные о внутреннем исключении
                Console.WriteLine($"[Main] Исключение: {ex.Message}");
                Console.WriteLine($"[Main] Внутреннее исключение: {ex.InnerException?.Message}");
                Console.WriteLine($"[Main] Стек вызовов: {ex.StackTrace}");
            }
        }
    }
}