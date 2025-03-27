using System;

// Класс, представляющий игрока
class Player
{
    public string Name { get; set; }

    public Player(string name)
    {
        Name = name;
    }

    public void Play()
    {
        Console.WriteLine($"{Name} играет в игру.");
    }
}

// Класс, представляющий мир игры
class GameWorld
{
    public string WorldName { get; set; }

    public GameWorld(string worldName)
    {
        WorldName = worldName;
    }

    public void DescribeWorld()
    {
        Console.WriteLine($"Мир игры: {WorldName}");
    }
}

// Класс, представляющий разработчика
class Developer
{
    public string DeveloperName { get; set; }

    public Developer(string developerName)
    {
        DeveloperName = developerName;
    }

    public void DevelopGame()
    {
        Console.WriteLine($"{DeveloperName} разрабатывает игру.");
    }
}

// Класс, представляющий видеоигру
class VideoGame
{
    // Агрегация: массив игроков
    public Player[] Players { get; set; }

    // Композиция: объект мира игры
    private GameWorld gameWorld;

    // Ассоциация: связь с разработчиком
    public Developer Developer { get; set; }

    public VideoGame(Player[] players, string worldName, Developer developer)
    {
        Players = players; // Инициализация массива игроков
        gameWorld = new GameWorld(worldName); // Создание мира игры
        Developer = developer; // Инициализация разработчика
    }

    // Метод для запуска игры
    public void StartGame()
    {
        Console.WriteLine("Игра начинается!");
        gameWorld.DescribeWorld(); // Описание мира игры
        Developer.DevelopGame(); // Разработчик начинает разработку игры

        // Каждый игрок начинает играть
        foreach (var player in Players)
        {
            player.Play();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем игроков
        Player player1 = new Player("Игрок 1");
        Player player2 = new Player("Игрок 2");

        // Создаем массив игроков
        Player[] players = new Player[] { player1, player2 };

        // Создаем разработчика
        Developer developer = new Developer("Разработчик 1");

        // Создаем видеоигру с миром и разработчиком
        VideoGame game = new VideoGame(players, "Фантастический мир", developer);

        // Запускаем игру
        game.StartGame();
    }
}
