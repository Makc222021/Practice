using System;
using System.Collections.Generic;

public class FontManager
{
    // Поле для хранения единственного экземпляра класса
    private static FontManager _instance;

    // Коллекция для хранения загруженных шрифтов
    private readonly Dictionary<string, string> _fonts;

    // Приватный конструктор для предотвращения создания экземпляров извне
    private FontManager()
    {
        _fonts = new Dictionary<string, string>();
    }

    // Статический метод для получения единственного экземпляра класса
    public static FontManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new FontManager();
            }
            return _instance;
        }
    }

    // Метод для загрузки шрифта
    public void LoadFont(string fontName)
    {
        if (string.IsNullOrWhiteSpace(fontName))
            throw new ArgumentException("Название шрифта не может быть пустым.", nameof(fontName));

        if (!_fonts.ContainsKey(fontName))
        {
            _fonts[fontName] = $"Шрифт '{fontName}' загружен."; // Заглушка для демонстрации загрузки
            Console.WriteLine($"Шрифт '{fontName}' успешно загружен.");
        }
        else
        {
            Console.WriteLine($"Шрифт '{fontName}' уже загружен.");
        }
    }

    // Метод для получения шрифта
    public string GetFont(string fontName)
    {
        if (string.IsNullOrWhiteSpace(fontName))
            throw new ArgumentException("Название шрифта не может быть пустым.", nameof(fontName));

        if (_fonts.TryGetValue(fontName, out var font))
        {
            return font;
        }
        else
        {
            Console.WriteLine($"Шрифт '{fontName}' не найден.");
            return null;
        }
    }
}

// Пример использования FontManager
public class Program
{
    public static void Main(string[] args)
    {
        // Получаем единственный экземпляр FontManager
        var fontManager = FontManager.Instance;

        // Загружаем шрифты
        fontManager.LoadFont("Arial");
        fontManager.LoadFont("Times New Roman");

        // Попытка загрузить уже существующий шрифт
        fontManager.LoadFont("Arial");

        // Получаем шрифты
        Console.WriteLine("\nПолучение шрифтов:");
        Console.WriteLine(fontManager.GetFont("Arial"));
        Console.WriteLine(fontManager.GetFont("Times New Roman"));

        // Попытка получить несуществующий шрифт
        Console.WriteLine(fontManager.GetFont("Calibri"));
    }
}
