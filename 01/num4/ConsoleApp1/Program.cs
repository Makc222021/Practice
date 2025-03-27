using System;

class Program
{
    static void Main()
    {
        double v = 10; // Скорость в стоячей воде в км/ч
        double v1 = 3; // Скорость течения реки в км/ч
        double t1 = 2; // Время движения по озеру в часах
        double t2 = 1; // Время движения против течения реки в часах

        double path1 = v * t1; // Путь лодки по озеру
        double path2 = (v - v1) * t2; // Путь лодки против течения реки

        double totalPath = path1 + path2; // Общий пройденный путь

        Console.WriteLine($"Общий пройденный путь лодкой: {totalPath} км");
    }
}