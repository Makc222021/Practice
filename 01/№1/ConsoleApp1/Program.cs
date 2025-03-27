using System;

class Program
{
    static void Main()
    {
        double distance = 67; // Расстояние до дачи в км
        double fuelConsumption = 8.5; // Расход бензина в литрах на 100 км пробега
        double pricePerLiter = 6.5; // Цена одного литра бензина в рублях

        double cost = (distance / 100) * fuelConsumption * pricePerLiter * 2; // 2 - для поездки туда и обратно

        Console.WriteLine($"Стоимость поездки на дачу и обратно составит: {cost} руб.");
    }
}