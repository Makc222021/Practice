using System;
using System.Collections;

namespace BankQueueExample
{
    // Класс Customer (клиент банка)
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ServiceType { get; set; } // Тип услуги (например, "Депозит", "Кредит")

        public Customer(int id, string name, string serviceType)
        {
            Id = id;
            Name = name;
            ServiceType = serviceType;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Имя: {Name}, Услуга: {ServiceType}";
        }
    }

    // Класс BankQueue для управления очередью клиентов
    public class BankQueue
    {
        private Queue _customers; // Используем недженерик коллекцию Queue

        public BankQueue()
        {
            _customers = new Queue();
        }

        // Добавление клиента в очередь
        public void AddCustomer(Customer customer)
        {
            _customers.Enqueue(customer);
            Console.WriteLine($"Клиент добавлен в очередь: {customer}");
        }

        // Обработка следующего клиента
        public void ProcessNextCustomer()
        {
            if (_customers.Count > 0)
            {
                Customer nextCustomer = (Customer)_customers.Dequeue();
                Console.WriteLine($"Обрабатывается клиент: {nextCustomer}");
            }
            else
            {
                Console.WriteLine("Очередь пуста. Нет клиентов для обработки.");
            }
        }

        // Отобразить всех клиентов в очереди
        public void DisplayQueue()
        {
            if (_customers.Count == 0)
            {
                Console.WriteLine("Очередь пуста.");
                return;
            }

            Console.WriteLine("Клиенты в очереди:");
            foreach (Customer customer in _customers)
            {
                Console.WriteLine(customer);
            }
        }

        // Поиск клиента по ID
        public void FindCustomerById(int id)
        {
            foreach (Customer customer in _customers)
            {
                if (customer.Id == id)
                {
                    Console.WriteLine($"Клиент найден: {customer}");
                    return;
                }
            }
            Console.WriteLine($"Клиент с ID {id} не найден в очереди.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем очередь в банке
            BankQueue bankQueue = new BankQueue();

            // Создаем несколько клиентов
            Customer customer1 = new Customer(1, "Иван Иванов", "Депозит");
            Customer customer2 = new Customer(2, "Мария Петрова", "Кредит");
            Customer customer3 = new Customer(3, "Алексей Смирнов", "Консультация");

            // Добавляем клиентов в очередь
            bankQueue.AddCustomer(customer1);
            bankQueue.AddCustomer(customer2);
            bankQueue.AddCustomer(customer3);

            // Отображаем всех клиентов в очереди
            Console.WriteLine();
            bankQueue.DisplayQueue();

            // Обрабатываем следующего клиента
            Console.WriteLine();
            bankQueue.ProcessNextCustomer();

            // Отображаем очередь после обработки одного клиента
            Console.WriteLine();
            bankQueue.DisplayQueue();

            // Поиск клиента по ID
            Console.WriteLine();
            bankQueue.FindCustomerById(2);
            bankQueue.FindCustomerById(4);
        }
    }
}