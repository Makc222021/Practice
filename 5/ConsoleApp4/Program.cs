using System;

namespace MediaFilterExample
{
    // Интерфейс для обработки изображений
    interface IImageFilter
    {
        void ApplyFilter(string filterName);
    }

    // Интерфейс для обработки видео
    interface IVideoFilter
    {
        void ApplyFilter(string filterName);
    }

    // Класс, реализующий оба интерфейса
    class MediaProcessor : IImageFilter, IVideoFilter
    {
        // Явная реализация метода IImageFilter.ApplyFilter
        void IImageFilter.ApplyFilter(string filterName)
        {
            Console.WriteLine($"Применение фильтра \"{filterName}\" к изображению...");
        }

        // Явная реализация метода IVideoFilter.ApplyFilter
        void IVideoFilter.ApplyFilter(string filterName)
        {
            Console.WriteLine($"Применение фильтра \"{filterName}\" к видео...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем объект класса MediaProcessor
            MediaProcessor processor = new MediaProcessor();

            // Используем ссылки на интерфейсы для вызова метода
            IImageFilter imageFilter = processor;
            IVideoFilter videoFilter = processor;

            // Вызов метода ApplyFilter через ссылку IImageFilter
            imageFilter.ApplyFilter("Чёрно-белый");

            // Вызов метода ApplyFilter через ссылку IVideoFilter
            videoFilter.ApplyFilter("Размытие");
        }
    }
}