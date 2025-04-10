using System;

// Абстрактный класс продукта - билет
public interface ITicket
{
    void Book();
}

// Конкретные классы продуктов - билеты различных видов транспорта
public class PlaneTicket : ITicket
{
    public void Book()
    {
        Console.WriteLine("Билет на самолет забронирован.");
    }
}

public class TrainTicket : ITicket
{
    public void Book()
    {
        Console.WriteLine("Билет на поезд забронирован.");
    }
}

public class BusTicket : ITicket
{
    public void Book()
    {
        Console.WriteLine("Билет на автобус забронирован.");
    }
}

// Абстрактная фабрика
public abstract class TicketFactory
{
    public abstract ITicket CreateTicket();
}

// Конкретные фабрики
public class PlaneFactory : TicketFactory
{
    public override ITicket CreateTicket()
    {
        return new PlaneTicket();
    }
}

public class TrainFactory : TicketFactory
{
    public override ITicket CreateTicket()
    {
        return new TrainTicket();
    }
}

public class BusFactory : TicketFactory
{
    public override ITicket CreateTicket()
    {
        return new BusTicket();
    }
}

public class Program
{
    public static void Main()
    {
        // Использование фабричного метода для создания и бронирования билетов
        TicketFactory planeFactory = new PlaneFactory();
        ITicket planeTicket = planeFactory.CreateTicket();
        planeTicket.Book();

        TicketFactory trainFactory = new TrainFactory();
        ITicket trainTicket = trainFactory.CreateTicket();
        trainTicket.Book();

        TicketFactory busFactory = new BusFactory();
        ITicket busTicket = busFactory.CreateTicket();
        busTicket.Book();
    }
}