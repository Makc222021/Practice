using System;

abstract class ElectronicDevice
{
    // Абстрактный метод, который должен быть реализован в наследниках
    public abstract void TurnOn();

    // Виртуальный метод, который может быть переопределен в наследниках
    public virtual void TurnOff()
    {
        Console.WriteLine("Device is turning off");
    }
}

class TV : ElectronicDevice
{
    // Реализация абстрактного метода TurnOn
    public override void TurnOn()
    {
        Console.WriteLine("TV is turning on");
    }

    // Переопределение метода TurnOff
    public override void TurnOff()
    {
        Console.WriteLine("TV is turning off");
    }
}

class Radio : ElectronicDevice
{
    // Реализация абстрактного метода TurnOn
    public override void TurnOn()
    {
        Console.WriteLine("Radio is turning on");
    }

    // Переопределение метода TurnOff
    public override void TurnOff()
    {
        Console.WriteLine("Radio is turning off");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ElectronicDevice myTV = new TV();
        myTV.TurnOn();
        myTV.TurnOff();

        ElectronicDevice myRadio = new Radio();
        myRadio.TurnOn();
        myRadio.TurnOff();
    }
}
