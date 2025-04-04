using System;
using System.IO;

public class FileWatcher
{
    private readonly string _directoryToWatch;
    private readonly string _logFilePath;

    public FileWatcher(string directoryToWatch, string logFilePath)
    {
        _directoryToWatch = directoryToWatch;
        _logFilePath = logFilePath;

        // Убедимся, что папка для отслеживания существует
        if (!Directory.Exists(_directoryToWatch))
        {
            Directory.CreateDirectory(_directoryToWatch);
            Console.WriteLine($"Создана папка для отслеживания: {_directoryToWatch}");
        }

        // Убедимся, что файл лога CSV существует
        if (!File.Exists(_logFilePath))
        {
            File.WriteAllText(_logFilePath, "EventType,FileName,Timestamp\n");
            Console.WriteLine($"Создан файл лога: {_logFilePath}");
        }
    }

    // Запуск FileSystemWatcher
    public void StartWatching()
    {
        using (var watcher = new FileSystemWatcher(_directoryToWatch))
        {
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.LastWrite;

            // Подписываемся на события
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Changed += OnChanged;
            watcher.Renamed += OnRenamed;

            watcher.IncludeSubdirectories = false; // Отслеживать только указанную директорию
            watcher.EnableRaisingEvents = true;

            Console.WriteLine($"Начато отслеживание папки: {_directoryToWatch}");
            Console.WriteLine("Нажмите Enter для завершения работы...");
            Console.ReadLine(); // Для предотвращения завершения программы
        }
    }

    // Обработка события создания файлов
    private void OnCreated(object sender, FileSystemEventArgs e)
    {
        LogEvent("Created", e.FullPath);
    }

    // Обработка события удаления файлов
    private void OnDeleted(object sender, FileSystemEventArgs e)
    {
        LogEvent("Deleted", e.FullPath);
    }

    // Обработка события изменения файлов
    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        LogEvent("Changed", e.FullPath);
    }

    // Обработка события переименования файлов
    private void OnRenamed(object sender, RenamedEventArgs e)
    {
        LogEvent("Renamed", $"{e.OldFullPath} -> {e.FullPath}");
    }

    // Метод для логирования события в файл CSV
    private void LogEvent(string eventType, string fileName)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string logEntry = $"{eventType},{fileName},{timestamp}\n";

        File.AppendAllText(_logFilePath, logEntry);
        Console.WriteLine($"[{timestamp}] Событие: {eventType}, Имя файла: {fileName}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Путь к папке для отслеживания
        string directoryToWatch = "D:/Практика C#/Этель_9/задание4/WatchedFolder";

        // Путь к файлу лога CSV
        string logFilePath = "D:/Практика C#/Этель_9/задание4/event_log.csv";

        // Создаем объект FileWatcher
        FileWatcher fileWatcher = new FileWatcher(directoryToWatch, logFilePath);

        // Запускаем отслеживание
        fileWatcher.StartWatching();
    }
}