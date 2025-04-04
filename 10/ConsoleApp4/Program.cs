using System;
using System.Collections.Generic;

namespace ObserverPatternExample
{
    // Интерфейс подписчика
    public interface ICurrencyObserver
    {
        void Update(string currency, decimal rate); // Метод для получения уведомлений
    }

    // Издатель (ForexMarket)
    public class ForexMarket
    {
        private readonly Dictionary<string, decimal> _currencyRates; // Курс валют
        private readonly List<ICurrencyObserver> _observers;         // Список подписчиков

        public ForexMarket()
        {
            _currencyRates = new Dictionary<string, decimal>();
            _observers = new List<ICurrencyObserver>();
        }

        // Регистрация подписчика
        public void Subscribe(ICurrencyObserver observer)
        {
            _observers.Add(observer);
            Console.WriteLine($"{observer.GetType().Name} подписан на обновления курсов валют.");
        }

        // Отмена подписки
        public void Unsubscribe(ICurrencyObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine($"{observer.GetType().Name} отписан от обновлений курсов валют.");
        }

        // Обновление курса валюты
        public void UpdateCurrencyRate(string currency, decimal rate)
        {
            _currencyRates[currency] = rate;
            Console.WriteLine($"[ForexMarket] Курс обновлен: {currency} = {rate}");
            NotifyObservers(currency, rate);
        }

        // Уведомление всех подписчиков
        private void NotifyObservers(string currency, decimal rate)
        {
            foreach (var observer in _observers)
            {
                observer.Update(currency, rate);
            }
        }
    }

    // Конкретный подписчик (Trader)
    public class Trader : ICurrencyObserver
    {
        public string Name { get; }

        public Trader(string name)
        {
            Name = name;
        }

        public void Update(string currency, decimal rate)
        {
            Console.WriteLine($"[Trader {Name}] Получено уведомление: {currency} = {rate}. Решаем, покупать или продавать...");
        }
    }

    // Конкретный подписчик (Bank)
    public class Bank : ICurrencyObserver
    {
        public string Name { get; }

        public Bank(string name)
        {
            Name = name;
        }

        public void Update(string currency, decimal rate)
        {
            Console.WriteLine($"[Bank {Name}] Получено уведомление: {currency} = {rate}. Рассчитываем финансовую стратегию.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем объект ForexMarket
            ForexMarket forexMarket = new ForexMarket();

            // Создаем подписчиков
            Trader trader1 = new Trader("Иван");
            Trader trader2 = new Trader("Мария");
            Bank bank1 = new Bank("Сбербанк");
            Bank bank2 = new Bank("ВТБ");

            // Подписываем подписчиков на обновления
            forexMarket.Subscribe(trader1);
            forexMarket.Subscribe(trader2);
            forexMarket.Subscribe(bank1);
            forexMarket.Subscribe(bank2);

            // Обновляем курсы валют
            Console.WriteLine();
            forexMarket.UpdateCurrencyRate("USD", 76.54m);
            forexMarket.UpdateCurrencyRate("EUR", 82.15m);

            // Отписываем одного подписчика
            Console.WriteLine();
            forexMarket.Unsubscribe(trader2);

            // Снова обновляем курсы валют
            Console.WriteLine();
            forexMarket.UpdateCurrencyRate("GBP", 92.30m);
        }
    }
}