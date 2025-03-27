using System;
using System.Collections.Generic;
using System.Linq;

// Класс, представляющий сотрудника
class Employee
{
    public string Name { get; set; }
    public string Department { get; set; }

    public Employee(string name, string department)
    {
        Name = name;
        Department = department;
    }
}

// Класс, представляющий компанию
class Company
{
    private static List<Employee> employees = new List<Employee>();

    // Статический метод для добавления сотрудников в список
    public static void AddEmployee(Employee employee)
    {
        employees.Add(employee);
    }

    // Статический метод для поиска сотрудников по отделу
    public static List<Employee> FindEmployeesByDepartment(string department)
    {
        return employees.Where(e => e.Department == department).ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Добавляем сотрудников в компанию
        Company.AddEmployee(new Employee("Иван Иванов", "IT"));
        Company.AddEmployee(new Employee("Петр Петров", "HR"));
        Company.AddEmployee(new Employee("Сидор Сидоров", "IT"));
        Company.AddEmployee(new Employee("Анна Аннова", "Finance"));
        Company.AddEmployee(new Employee("Мария Маринова", "IT"));

        // Ищем сотрудников из отдела IT
        string department = "IT";
        List<Employee> itEmployees = Company.FindEmployeesByDepartment(department);

        // Выводим результаты
        Console.WriteLine($"Сотрудники отдела {department}:");
        foreach (var employee in itEmployees)
        {
            Console.WriteLine(employee.Name);
        }
    }
}
