using System;
using System.Collections.Generic;

// Базовый класс для офисной техники
public class OfficeEquipment
{
    public string Brand { get; set; } // Марка оборудования

    public OfficeEquipment(string brand)
    {
        Brand = brand;
    }
}

// Интерфейс для принтеров
public interface IPrinter
{
    void Print(); // Метод для печати
}

// Интерфейс для сканеров
public interface IScanner
{
    void Scan(); // Метод для сканирования
}

// Класс лазерного принтера
public class LaserPrinter : OfficeEquipment, IPrinter
{
    public LaserPrinter(string brand) : base(brand) { }

    public void Print()
    {
        Console.WriteLine($"{Brand} лазерный принтер печатает.");
    }
}

// Класс документационного сканера
public class DocumentScanner : OfficeEquipment, IScanner
{
    public DocumentScanner(string brand) : base(brand) { }

    public void Scan()
    {
        Console.WriteLine($"{Brand} документный сканер сканирует.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем массив офисной техники
        OfficeEquipment[] officeEquipmentArray = new OfficeEquipment[]
        {
            new LaserPrinter("HP"),
            new DocumentScanner("Canon"),
            new LaserPrinter("Epson"),
            new DocumentScanner("Fujitsu")
        };

        // Находим все сканеры в массиве
        List<IScanner> scanners = new List<IScanner>();
        foreach (var equipment in officeEquipmentArray)
        {
            if (equipment is IScanner scanner) // Проверяем, является ли оборудование сканером
            {
                scanners.Add(scanner);
            }
        }

        // Выводим информацию о найденных сканерах
        Console.WriteLine("Найденные сканеры:");
        foreach (var scanner in scanners)
        {
            scanner.Scan(); // Вызываем метод сканирования
        }
    }
}
