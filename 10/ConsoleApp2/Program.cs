using System;

// Интерфейс стратегии
interface ITaxStrategy
{
    double CalculateTax(double income);
}

// Класс для расчета налога
class TaxCalculator
{
    private ITaxStrategy _taxStrategy;

    // Установка стратегии
    public void SetTaxStrategy(ITaxStrategy taxStrategy)
    {
        _taxStrategy = taxStrategy;
    }

    // Расчет налога с использованием текущей стратегии
    public double CalculateTax(double income)
    {
        if (_taxStrategy == null)
        {
            throw new InvalidOperationException("Стратегия налогообложения не установлена");
        }

        return _taxStrategy.CalculateTax(income);
    }
}

// Конкретная стратегия для налогообложения в США
class USTax : ITaxStrategy
{
    public double CalculateTax(double income)
    {
        // Просто для примера, реальная логика расчета налога может быть более сложной
        return income * 0.15;
    }
}

// Конкретная стратегия для налогообложения в Европейском союзе
class EUTax : ITaxStrategy
{
    public double CalculateTax(double income)
    {
        return income * 0.20;
    }
}

// Конкретная стратегия для налогообложения в Азии
class AsiaTax : ITaxStrategy
{
    public double CalculateTax(double income)
    {
        return income * 0.10;
    }
}

class Program
{
    static void Main()
    {
        TaxCalculator taxCalculator = new TaxCalculator();

        // Установка стратегии налогообложения
        taxCalculator.SetTaxStrategy(new USTax());
        double usTax = taxCalculator.CalculateTax(10000);
        Console.WriteLine($"Налог для США: {usTax}");

        taxCalculator.SetTaxStrategy(new EUTax());
        double euTax = taxCalculator.CalculateTax(10000);
        Console.WriteLine($"Налог для Европейского союза: {euTax}");

        taxCalculator.SetTaxStrategy(new AsiaTax());
        double asiaTax = taxCalculator.CalculateTax(10000);
        Console.WriteLine($"Налог для Азии: {asiaTax}");
    }
}