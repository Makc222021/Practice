using System;

// Класс для отслеживания загрузки файлов
class FileDownloader
{
    // Событие изменения прогресса загрузки
    public event EventHandler<int> DownloadProgressChanged;

    // Метод для имитации загрузки файла
    public void DownloadFile()
    {
        for (int i = 0; i <= 100; i += 10)
        {
            OnDownloadProgressChanged(i);
            System.Threading.Thread.Sleep(500); // Задержка для имитации загрузки
        }
    }

    // Метод для генерации события DownloadProgressChanged
    protected virtual void OnDownloadProgressChanged(int progress)
    {
        DownloadProgressChanged?.Invoke(this, progress);
    }
}

// Промежуточный класс для мониторинга загрузки
class DownloadMonitor
{
    // Метод подписывает ProgressBar на событие DownloadProgressChanged
    public void UpdateProgressBar(object sender, int progress)
    {
        Console.WriteLine($"Прогресс загрузки: {progress}%");
    }

    // Метод подписывает Logger на событие DownloadProgressChanged
    public void LogProgress(object sender, int progress)
    {
        Console.WriteLine($"Лог: Загрузка на {progress}% завершена");
    }
}

class Program
{
    static void Main()
    {
        FileDownloader downloader = new FileDownloader();
        DownloadMonitor monitor = new DownloadMonitor();

        // Подписываем ProgressBar и Logger на событие DownloadProgressChanged
        downloader.DownloadProgressChanged += monitor.UpdateProgressBar;
        downloader.DownloadProgressChanged += monitor.LogProgress;

        // Запускаем загрузку файла
        downloader.DownloadFile();

        Console.ReadLine();
    }
}