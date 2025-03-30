using System;
using System.Collections.Generic;

namespace CustomGenericCollectionExample
{
    // Класс MyMultiMap<TKey, TValue> — дженерик-коллекция
    public class MyMultiMap<TKey, TValue>
    {
        // Словарь, где ключу соответствует список значений
        private readonly Dictionary<TKey, List<TValue>> _map;

        // Конструктор
        public MyMultiMap()
        {
            _map = new Dictionary<TKey, List<TValue>>();
        }

        // Добавление значения по ключу
        public void Add(TKey key, TValue value)
        {
            if (!_map.ContainsKey(key))
            {
                _map[key] = new List<TValue>();
            }
            _map[key].Add(value);
            Console.WriteLine($"Добавлено: Ключ = {key}, Значение = {value}");
        }

        // Удаление значения по ключу
        public bool Remove(TKey key, TValue value)
        {
            if (_map.TryGetValue(key, out var values))
            {
                if (values.Remove(value))
                {
                    Console.WriteLine($"Удалено: Ключ = {key}, Значение = {value}");
                    // Если список значений пуст, удаляем ключ
                    if (values.Count == 0)
                    {
                        _map.Remove(key);
                    }
                    return true;
                }
            }
            Console.WriteLine($"Не удалось удалить: Ключ = {key}, Значение = {value}");
            return false;
        }

        // Поиск значений по ключу
        public List<TValue> Find(TKey key)
        {
            if (_map.TryGetValue(key, out var values))
            {
                return values;
            }
            return null;
        }

        // Отображение всех ключей и значений
        public void Display()
        {
            Console.WriteLine("Содержимое MyMultiMap:");
            foreach (var pair in _map)
            {
                Console.WriteLine($"Ключ: {pair.Key}, Значения: {string.Join(", ", pair.Value)}");
            }
        }
    }

    // Класс MultiMapManager<TKey, TValue> — бизнес-логика
    public class MultiMapManager<TKey, TValue>
    {
        private readonly MyMultiMap<TKey, TValue> _multiMap;

        // Конструктор
        public MultiMapManager()
        {
            _multiMap = new MyMultiMap<TKey, TValue>();
        }

        // Добавление элемента
        public void AddElement(TKey key, TValue value)
        {
            _multiMap.Add(key, value);
        }

        // Удаление элемента
        public void RemoveElement(TKey key, TValue value)
        {
            _multiMap.Remove(key, value);
        }

        // Поиск и отображение значений по ключу
        public void FindAndDisplay(TKey key)
        {
            var values = _multiMap.Find(key);
            if (values != null)
            {
                Console.WriteLine($"Найдено для ключа {key}: {string.Join(", ", values)}");
            }
            else
            {
                Console.WriteLine($"Для ключа {key} ничего не найдено.");
            }
        }

        // Отображение всей коллекции
        public void DisplayAll()
        {
            _multiMap.Display();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем менеджер для работы с MyMultiMap
            MultiMapManager<string, string> manager = new MultiMapManager<string, string>();

            // Добавление элементов
            manager.AddElement("Понедельник", "Собрание");
            manager.AddElement("Понедельник", "Отчет");
            manager.AddElement("Вторник", "Презентация");
            manager.AddElement("Среда", "Обучение");

            // Отображение всей коллекции
            Console.WriteLine();
            manager.DisplayAll();

            // Поиск значений по ключу
            Console.WriteLine();
            manager.FindAndDisplay("Понедельник");
            manager.FindAndDisplay("Пятница");

            // Удаление значения
            Console.WriteLine();
            manager.RemoveElement("Понедельник", "Собрание");
            manager.RemoveElement("Понедельник", "Не существует");

            // Отображение всей коллекции после удаления
            Console.WriteLine();
            manager.DisplayAll();
        }
    }
}