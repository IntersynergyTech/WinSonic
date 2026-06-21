using WinSonic.Player;
using WinSonic.Subsonic.Helpers;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var player = AudioPlayerBuilder.Default().Build();
        ConnectToServer();
        PlayAudio();
        

    }

    static void ConnectToServer()
    {
        Console.WriteLine("Connecting to server");
        var builder = new SubsonicConnectionBuilder().WithDefaultUserCredentials();

        var client = builder.Build();

        Console.WriteLine("Requesting playlists");
        var playlistResponse = client.Playlists.GetPlaylists();

        Console.WriteLine("Found playlists:");

        var index = 0;

        var playlists = playlistResponse.SubsonicResponse.GetGetPlaylistsSuccessResponse().Playlists.Playlist;
        
        foreach (var playlist in playlists)
        {
            Console.WriteLine($"[{index++}]: [{playlist.Id}] {playlist.Name} (by {playlist.Owner}, {playlist.SongCount} songs, {TimeSpan.FromSeconds(playlist.Duration).ToString(@"hh\:mm\:ss")})");
        }
        
        Console.WriteLine("Enter playlist number:");
        var playlistNumber = Convert.ToInt32(Console.ReadLine());
        
        var fullPlaylistResponse = client.Playlists.GetPlaylist(playlists[playlistNumber].Id);

        var fullPlaylist = fullPlaylistResponse.SubsonicResponse.GetGetPlaylistSuccessResponse().Playlist;

        var first10 = fullPlaylist.Entry.Take(10).ToList();

        Console.WriteLine($"First 10 songs from {fullPlaylist.Name}:");
        foreach (var item in first10)
        {
            Console.WriteLine($"[{item.Id}] {item.Title} (by {item.Artist}, {TimeSpan.FromSeconds(item.Duration).ToString(@"hh\:mm\:ss")})");
        }

        Console.WriteLine("Playing something.");
    }

    static void PlayAudio()
    {
        var player = AudioPlayerBuilder.Default().Build();
        player.LoadFile(@"C:\Users\butle\Downloads\MUSICDOWNLOADS\05_Unravel.wav");
        player.StartPlayback();
        Console.ReadLine();
    }
}