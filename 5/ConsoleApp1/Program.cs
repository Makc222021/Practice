using System;

// Абстрактный класс для методов доставки
abstract class DeliveryMethod
{
    // Абстрактный метод, который должен быть реализован в наследниках
    public abstract void Deliver();
}

// Класс для курьерской доставки
class Courier : DeliveryMethod
{
    // Реализация метода Deliver для курьерской доставки
    public override void Deliver()
    {
        Console.WriteLine("Доставка курьером: ваш товар будет доставлен к вашей двери.");
    }
}

// Класс для самовывоза
class Pickup : DeliveryMethod
{
    // Реализация метода Deliver для самовывоза
    public override void Deliver()
    {
        Console.WriteLine("Самовывоз: вы можете забрать ваш товар в нашем магазине.");
    }
}

// Класс для почтовой доставки
class Post : DeliveryMethod
{
    // Реализация метода Deliver для почтовой доставки
    public override void Deliver()
    {
        Console.WriteLine("Почтовая доставка: ваш товар будет отправлен по почте.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем массив способов доставки
        DeliveryMethod[] deliveryMethods = new DeliveryMethod[]
        {
            new Courier(), // Добавляем курьерскую доставку
            new Pickup(),  // Добавляем самовывоз
            new Post()     // Добавляем почтовую доставку
        };

        // Выполняем работу каждого способа доставки
        foreach (var method in deliveryMethods)
        {
            method.Deliver(); // Вызываем метод Deliver для каждого способа доставки
        }
    }
}
