using System;
using System.IO;

class FileOperations
{
    static void Main()
    {
        string originalFile = "example.txt";
        string copyFile = "example_copy.txt";
        string newDir = "moved_dir";
        string renamedFile = "etel.mv";

        // 1. Создать файл и записать текст
        File.WriteAllText(originalFile, "Привет, мир!");
        Console.WriteLine("1. Файл создан и в него записан текст:");
        Console.WriteLine(File.ReadAllText(originalFile));

        // 2. Проверить существование файла перед удалением
        if (File.Exists(originalFile))
        {
            File.Delete(originalFile);
            Console.WriteLine("\n2. Файл удалён после проверки его существования");
        }

        // Восстанавливаем файл для следующих операций
        File.WriteAllText(originalFile, "Восстановленное содержимое");

        // 3. Получить информацию о файле
        FileInfo fi = new FileInfo(originalFile);
        Console.WriteLine("\n3. Информация о файле:");
        Console.WriteLine($"Размер: {fi.Length} байт");
        Console.WriteLine($"Дата создания: {fi.CreationTime}");
        Console.WriteLine($"Дата изменения: {fi.LastWriteTime}");

        // 4. Копировать файл
        File.Copy(originalFile, copyFile, true);
        Console.WriteLine($"\n4. Файл скопирован. Копия существует: {File.Exists(copyFile)}");

        // 5. Переместить файл в новую директорию
        Directory.CreateDirectory(newDir);
        string movedFile = Path.Combine(newDir, Path.GetFileName(copyFile));
        File.Move(copyFile, movedFile);
        Console.WriteLine($"\n5. Файл перемещён. Существует в новом месте: {File.Exists(movedFile)}");

        // 6. Переименовать файл
        string finalPath = Path.Combine(newDir, renamedFile);
        File.Move(movedFile, finalPath);
        Console.WriteLine($"\n6. Файл переименован. Новое имя существует: {File.Exists(finalPath)}");

        // 7. Обработать ошибку при удалении несуществующего файла
        try
        {
            File.Delete("несуществующий_файл.txt");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"\n7. Обработка ошибки: {ex.Message}");
        }

        // 8. Сравнить два файла по размеру
        long size1 = new FileInfo(originalFile).Length;
        long size2 = new FileInfo(finalPath).Length;
        Console.WriteLine($"\n8. Сравнение размеров: {(size1 == size2 ? "Равны" : "Различаются")}");

        // 9. Удалить файлы по шаблону .mv
        foreach (string file in Directory.GetFiles(newDir, "*.mv"))
        {
            File.Delete(file);
        }
        Console.WriteLine($"\n9. Удалены файлы .mv. Файл {renamedFile} существует: {File.Exists(finalPath)}");

        // 10. Вывести список файлов в директории
        Console.WriteLine("\n10. Файлы в текущей директории:");
        foreach (string file in Directory.GetFiles(Directory.GetCurrentDirectory()))
        {
            Console.WriteLine(Path.GetFileName(file));
        }

        // 11. Запретить запись и попытаться записать
        File.SetAttributes(originalFile, FileAttributes.ReadOnly);
        try
        {
            File.AppendAllText(originalFile, "Новый текст");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"\n11. Предотвращение записи: {ex.Message}");
        }
        finally
        {
            File.SetAttributes(originalFile, FileAttributes.Normal);
        }

        // 12. Проверить права доступа
        Console.WriteLine("\n12. Проверка прав доступа к файлу:");
        try
        {
            // Проверка на чтение
            using (FileStream fs = File.OpenRead(originalFile))
            {
                Console.WriteLine("Чтение: разрешено");
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Чтение: запрещено");
        }

        try
        {
            // Проверка на запись
            using (FileStream fsa = File.OpenWrite(originalFile))
            {
                Console.WriteLine("Запись: разрешена");
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Запись: запрещена");
        }

        Console.WriteLine("Выполнение: не применимо для файлов в Windows");
    }
}