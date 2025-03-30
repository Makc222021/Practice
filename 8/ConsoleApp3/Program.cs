using System;
using System.Collections.Generic;

// Обобщенный интерфейс управления списками
public interface IListManager<T>
{
    void Add(T item);              // Добавление элемента в список
    void Remove(T item);           // Удаление элемента из списка
    T GetAt(int index);            // Получение элемента по индексу
    IEnumerable<T> GetAll();       // Получение всех элементов списка
}

// Реализация интерфейса с использованием List<T>
public class SimpleListManager<T> : IListManager<T>
{
    private readonly List<T> _items;

    public SimpleListManager()
    {
        _items = new List<T>();
    }

    public void Add(T item)
    {
        _items.Add(item);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
    }

    public T GetAt(int index)
    {
        if (index < 0 || index >= _items.Count)
            throw new ArgumentOutOfRangeException(nameof(index), "Индекс вне диапазона.");
        return _items[index];
    }

    public IEnumerable<T> GetAll()
    {
        return _items;
    }
}

// Класс бизнес-логики, выполняющий простые операции
public class ListManager<T>
{
    private readonly IListManager<T> _listManager;

    public ListManager(IListManager<T> listManager)
    {
        _listManager = listManager;
    }

    // Вывод всех элементов списка
    public void PrintAll()
    {
        foreach (var item in _listManager.GetAll())
        {
            Console.WriteLine(item);
        }
    }

    // Проверка, содержится ли элемент в списке
    public bool Contains(T item)
    {
        foreach (var element in _listManager.GetAll())
        {
            if (EqualityComparer<T>.Default.Equals(element, item))
                return true;
        }
        return false;
    }
}

// Пример использования
public class Program
{
    public static void Main(string[] args)
    {
        // Создаем экземпляр SimpleListManager и передаем его в ListManager
        var simpleListManager = new SimpleListManager<string>();
        var listManager = new ListManager<string>(simpleListManager);

        // Добавляем элементы в список
        simpleListManager.Add("Первый");
        simpleListManager.Add("Второй");
        simpleListManager.Add("Третий");

        // Выводим все элементы списка
        Console.WriteLine("Список элементов:");
        listManager.PrintAll();

        // Проверяем наличие элемента
        Console.WriteLine("\nСодержится ли элемент 'Второй': " + listManager.Contains("Второй"));

        // Удаляем элемент и снова выводим список
        simpleListManager.Remove("Второй");
        Console.WriteLine("\nСписок после удаления элемента 'Второй':");
        listManager.PrintAll();

        // Получаем элемент по индексу
        Console.WriteLine("\nЭлемент по индексу 1: " + simpleListManager.GetAt(1));
    }
}
