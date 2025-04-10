using System;

namespace LoggingSystem
{
    // Интерфейс ILogger определяет метод для логирования сообщений
    public interface ILogger
    {
        string Log(string message);
    }

    // Конкретный компонент: BasicLogger - базовый логгер без декораторов
    public class BasicLogger : ILogger
    {
        public string Log(string message)
        {
            return message;
        }
    }

    // Базовый класс декоратора, реализует общую логику декораторов
    public abstract class LoggerDecorator : ILogger
    {
        private readonly ILogger _logger;

        protected LoggerDecorator(ILogger logger)
        {
            _logger = logger;
        }

        // Реализация метода Log через делегирование декорированному логгеру
        public virtual string Log(string message)
        {
            return _logger.Log(message);
        }
    }

    // Декоратор: TimestampDecorator - добавляет временную метку к сообщению
    public class TimestampDecorator : LoggerDecorator
    {
        public TimestampDecorator(ILogger logger) : base(logger) { }

        public override string Log(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return $"{timestamp} - {base.Log(message)}";
        }
    }

    // Декоратор: SeverityDecorator - добавляет уровень важности к сообщению
    public class SeverityDecorator : LoggerDecorator
    {
        private readonly string _severity;

        public SeverityDecorator(ILogger logger, string severity) : base(logger)
        {
            _severity = severity;
        }

        public override string Log(string message)
        {
            return $"[{_severity.ToUpper()}] {base.Log(message)}";
        }
    }

    // Декоратор: UserDecorator - добавляет информацию о пользователе к сообщению
    public class UserDecorator : LoggerDecorator
    {
        private readonly string _username;

        public UserDecorator(ILogger logger, string username) : base(logger)
        {
            _username = username;
        }

        public override string Log(string message)
        {
            return $"{base.Log(message)} (User: {_username})";
        }
    }

    // Точка входа в программу
    class Program
    {
        static void Main(string[] args)
        {
            // Создание базового логгера
            ILogger basicLogger = new BasicLogger();

            // Декорирование логгера последовательно с Timestamp, Severity и User информацией
            ILogger loggerWithTimestamp = new TimestampDecorator(basicLogger);
            ILogger loggerWithSeverity = new SeverityDecorator(loggerWithTimestamp, "INFO");
            ILogger loggerWithUser = new UserDecorator(loggerWithSeverity, "admin");

            // Логирование сообщения
            string logMessage = loggerWithUser.Log("Система успешно запущена.");
            Console.WriteLine(logMessage);

            // Пример с другим уровнем важности (ERROR) и другим пользователем (guest)
            ILogger errorLogger = new UserDecorator(
                new SeverityDecorator(
                    new TimestampDecorator(new BasicLogger()),
                    "ERROR"
                ),
                "guest"
            );

            string errorMessage = errorLogger.Log("Произошла ошибка при обработке данных.");
            Console.WriteLine(errorMessage);
        }
    }
}