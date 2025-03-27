using System;

class A
{
    private int a; // Поле a
    private int b; // Поле b

    // Конструктор для инициализации a и b
    public A(int a, int b)
    {
        this.a = a;
        this.b = b;
    }

    // Метод вычисления значения выражения ((4)/(a+2))*b
    public double CalculateExpression()
    {
        if (a + 2 == 0)
        {
            throw new DivideByZeroException("Деление на ноль в выражении ((4)/(a+2))*b");
        }
        return (4.0 / (a + 2)) * b;
    }

    // Метод вычисления b^10
    public long CalculateBPower10()
    {
        return (long)Math.Pow(b, 10);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание объекта класса A
        A obj = new A(3, 2); // Инициализация объекта с a=3 и b=2

        // Вызов методов и вывод результатов
        try
        {
            double expressionResult = obj.CalculateExpression();
            Console.WriteLine("Результат выражения ((4)/(a+2))*b: " + expressionResult);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }

        long bPower10Result = obj.CalculateBPower10();
        Console.WriteLine("Результат возведения b в степень 10: " + bPower10Result);
    }
}
