using System;

// Класс для обработки данных
class DataProcessor
{
    // Событие завершения обработки данных
    public event EventHandler ProcessingCompleted;

    // Метод для обработки данных и генерации события
    public void ProcessData()
    {
        Console.WriteLine("Обработка данных...");

        // Предположим, здесь происходит обработка данных

        // Генерируем событие о завершении обработки данных
        OnProcessingCompleted();
    }

    // Метод для генерации события ProcessingCompleted
    protected virtual void OnProcessingCompleted()
    {
        ProcessingCompleted?.Invoke(this, EventArgs.Empty);
    }
}

// Класс для создания отчета
class ReportGenerator
{
    // Метод, подписанный на событие ProcessingCompleted
    public void GenerateReport(object sender, EventArgs e)
    {
        Console.WriteLine("Создание отчета...");
    }
}

// Класс для оповещения пользователя
class Notifier
{
    // Метод, подписанный на событие ProcessingCompleted
    public void NotifyUser(object sender, EventArgs e)
    {
        Console.WriteLine("Пользователь оповещен о завершении обработки данных.");
    }
}

class Program
{
    static void Main()
    {
        DataProcessor processor = new DataProcessor();
        ReportGenerator reportGenerator = new ReportGenerator();
        Notifier notifier = new Notifier();

        // Подписываемся на событие ProcessingCompleted
        processor.ProcessingCompleted += reportGenerator.GenerateReport;
        processor.ProcessingCompleted += notifier.NotifyUser;

        // Запускаем обработку данных
        processor.ProcessData();

        Console.ReadLine();
    }
}