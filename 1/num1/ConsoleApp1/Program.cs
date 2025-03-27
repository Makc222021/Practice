using System;

class Program
{
    static void Main(string[] args)
    {
        // Фиксированные стоимости компонентов
        double monitorPrice = 5000.0;    // Стоимость монитора
        double systemUnitPrice = 20000.0; // Стоимость системного блока
        double keyboardPrice = 1000.0;   // Стоимость клавиатуры
        double mousePrice = 500.0;       // Стоимость мыши

        // Считаем стоимость одного компьютера
        double computerPrice = monitorPrice + systemUnitPrice + keyboardPrice + mousePrice;

        Console.WriteLine($"Стоимость одного компьютера: {computerPrice} руб.");

        // Рассчитываем стоимость 3 компьютеров
        Console.WriteLine($"Стоимость 3 компьютеров: {computerPrice * 3} руб.");

        // Ввод количества компьютеров N
        Console.Write("Введите количество компьютеров (N): ");
        int n = int.Parse(Console.ReadLine());

        // Рассчитываем стоимость N компьютеров
        Console.WriteLine($"Стоимость {n} компьютеров: {computerPrice * n} руб.");
    }
}