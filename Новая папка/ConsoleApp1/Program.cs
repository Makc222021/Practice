using System;

// Делегат для работы с заказами
delegate void OrderHandler(string order);

// Класс для приготовления заказа
class CookOrder
{
    public void PrepareOrder(string order)
    {
        Console.WriteLine($"Приготовление заказа: {order}");
    }
}

// Класс для доставки заказа
class DeliverOrder
{
    public void Deliver(string order)
    {
        Console.WriteLine($"Доставка заказа: {order}");
    }
}

class Program
{
    static void Main()
    {
        // Создаем экземпляры классов CookOrder и DeliverOrder
        CookOrder cook = new CookOrder();
        DeliverOrder deliver = new DeliverOrder();

        // Создаем экземпляр делегата OrderHandler и добавляем методы PrepareOrder и Deliver
        OrderHandler orderHandler = cook.PrepareOrder;
        orderHandler += deliver.Deliver;

        // Вызываем делегат для обработки заказа
        orderHandler("Пицца");

        // Убираем метод Deliver и вызываем делегат снова
        orderHandler -= deliver.Deliver;
        orderHandler("Суши");

        // Ожидание ввода перед завершением программы
        Console.ReadLine();
    }
}