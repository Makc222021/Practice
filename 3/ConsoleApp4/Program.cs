using System;
using System.Collections.Generic;
using System.Linq;

// Первая часть partial класса User
partial class User
{
    public string Username { get; set; }
    public int FollowersCount { get; set; }
    public int PostsCount { get; set; }
    public DateTime LastActiveDate { get; set; }

    public User(string username, int followersCount, int postsCount, DateTime lastActiveDate)
    {
        Username = username;
        FollowersCount = followersCount;
        PostsCount = postsCount;
        LastActiveDate = lastActiveDate;
    }
}

// Вторая часть partial класса User
partial class User
{
    public void DisplayInfo()
    {
        Console.WriteLine($"Username: {Username}, Followers: {FollowersCount}, Posts: {PostsCount}, Last Active: {LastActiveDate:yyyy-MM-dd}");
    }
}

// Класс SocialNetwork
class SocialNetwork
{
    private User[] users;

    public SocialNetwork(User[] users)
    {
        this.users = users;
    }

    // Метод для поиска самых популярных пользователей
    public List<User> GetMostPopularUsers(int minFollowers)
    {
        return users.Where(u => u.FollowersCount >= minFollowers).ToList();
    }

    // Метод для поиска неактивных пользователей
    public List<User> GetInactiveUsers(int days)
    {
        DateTime cutoffDate = DateTime.Now.AddDays(-days);
        return users.Where(u => u.LastActiveDate < cutoffDate).ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем пользователей
        User[] users = {
            new User("Alice", 1500, 45, new DateTime(2025, 3, 20)),
            new User("Bob", 500, 30, new DateTime(2025, 3, 10)),
            new User("Charlie", 2500, 100, new DateTime(2025, 3, 25)),
            new User("David", 800, 60, new DateTime(2025, 2, 15))
        };

        // Создаем социальную сеть
        SocialNetwork socialNetwork = new SocialNetwork(users);

        // Находим самых популярных пользователей
        int minFollowers = 1000;
        var popularUsers = socialNetwork.GetMostPopularUsers(minFollowers);
        Console.WriteLine($"Пользователи с количеством подписчиков больше {minFollowers}:");
        foreach (var user in popularUsers)
        {
            user.DisplayInfo();
        }

        // Находим неактивных пользователей
        int inactiveDays = 30;
        var inactiveUsers = socialNetwork.GetInactiveUsers(inactiveDays);
        Console.WriteLine($"\nПользователи, неактивные более {inactiveDays} дней:");
        foreach (var user in inactiveUsers)
        {
            user.DisplayInfo();
        }
    }
}
