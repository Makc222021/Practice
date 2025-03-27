using System;

class Program
{
    static void Main()
    {
        // Первый набор чисел
        double A1 = 1.5, B1 = 2.5, C1 = 3.5;
        Console.WriteLine($"Исходный набор 1: A1 = {A1}, B1 = {B1}, C1 = {C1}");
        ShiftLeft3(ref A1, ref B1, ref C1);
        Console.WriteLine($"После сдвига:    A1 = {A1}, B1 = {B1}, C1 = {C1}\n");

        // Второй набор чисел
        double A2 = 4.5, B2 = 5.5, C2 = 6.5;
        Console.WriteLine($"Исходный набор 2: A2 = {A2}, B2 = {B2}, C2 = {C2}");
        ShiftLeft3(ref A2, ref B2, ref C2);
        Console.WriteLine($"После сдвига:    A2 = {A2}, B2 = {B2}, C2 = {C2}");
    }

    static void ShiftLeft3(ref double A, ref double B, ref double C)
    {
        double temp = A;  // Сохраняем исходное значение A
        A = B;            // B → A
        B = C;            // C → B
        C = temp;         // Исходное A → C
    }
}
