using System;
using System.Collections.Generic;
using System.Linq;

// Абстрактный класс MusicAlbum
abstract class MusicAlbum
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public int ReleaseYear { get; set; }
    public int TrackCount { get; set; }

    protected MusicAlbum(string title, string artist, int releaseYear, int trackCount)
    {
        Title = title;
        Artist = artist;
        ReleaseYear = releaseYear;
        TrackCount = trackCount;
    }

    public abstract void DisplayInfo();
}

// Запечатанный класс RockAlbum
sealed class RockAlbum : MusicAlbum
{
    public RockAlbum(string title, string artist, int releaseYear, int trackCount)
        : base(title, artist, releaseYear, trackCount)
    {
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Rock Album: {Title} by {Artist}, Released: {ReleaseYear}, Tracks: {TrackCount}");
    }
}

// Запечатанный класс PopAlbum
sealed class PopAlbum : MusicAlbum
{
    public PopAlbum(string title, string artist, int releaseYear, int trackCount)
        : base(title, artist, releaseYear, trackCount)
    {
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Pop Album: {Title} by {Artist}, Released: {ReleaseYear}, Tracks: {TrackCount}");
    }
}

// Класс MusicLibrary
class MusicLibrary
{
    private MusicAlbum[] albums;

    public MusicLibrary(MusicAlbum[] albums)
    {
        this.albums = albums;
    }

    // Метод для поиска самого нового альбома
    public MusicAlbum GetNewestAlbum()
    {
        if (albums.Length == 0)
            throw new InvalidOperationException("Библиотека альбомов пуста.");

        return albums.OrderByDescending(a => a.ReleaseYear).First();
    }

    // Метод для поиска альбомов по исполнителю
    public List<MusicAlbum> GetAlbumsByArtist(string artist)
    {
        return albums.Where(a => a.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем несколько альбомов
        MusicAlbum[] albums = {
            new RockAlbum("Back in Black", "AC/DC", 1980, 10),
            new PopAlbum("Thriller", "Michael Jackson", 1982, 9),
            new RockAlbum("The Dark Side of the Moon", "Pink Floyd", 1973, 10),
            new PopAlbum("Bad", "Michael Jackson", 1987, 11)
        };

        // Создаем библиотеку альбомов
        MusicLibrary library = new MusicLibrary(albums);

        // Находим самый новый альбом
        try
        {
            var newestAlbum = library.GetNewestAlbum();
            Console.WriteLine("Самый новый альбом:");
            newestAlbum.DisplayInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Находим альбомы по исполнителю
        string artist = "Michael Jackson";
        var albumsByArtist = library.GetAlbumsByArtist(artist);
        Console.WriteLine($"\nАльбомы исполнителя {artist}:");
        foreach (var album in albumsByArtist)
        {
            album.DisplayInfo();
        }
    }
}
