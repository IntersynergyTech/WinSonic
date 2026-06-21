using System.Diagnostics;
using WinSonic.Core;
using WinSonic.Player;
using WinSonic.Subsonic.Helpers;


internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var player = AudioPlayerBuilder.Default().Build();

        _storageManager = new StorageManager();
        _storageManager.EnsureDirectoriesExist();
        
        ConnectToServer();
        PlayAudio();
        

    }

    public static PlayQueue _playQueue { get; set; }
    public static StorageManager _storageManager { get; set; }
    public static SongFetcher _songFetcher { get; set; }

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

        var playlistObject = fullPlaylist.ToPlaylist();

        _playQueue = new PlayQueue();
        
        _playQueue.ResetAndEnqueueFromSource(playlistObject.Entries, true);

        Console.WriteLine($"Playing {fullPlaylist.Name}:");
        foreach (var item in _playQueue.EnumerateQueue())
        {
            Console.WriteLine($"[{item.Id}] {item.Title} (by {item.Artist}, {item.Duration.ToString(@"mm\:ss")})");
        }

        _songFetcher = new SongFetcher(client, _storageManager);
        
        Console.WriteLine("Starting Playback. (hopefully)");
    }

    static void PlayAudio()
    {
        var playlistItem = _playQueue.Dequeue();
        Console.WriteLine($"Now Playing: {playlistItem.Title} by {playlistItem.Artist}");
        var player = AudioPlayerBuilder.Default().Build();
        var songStream = _songFetcher.FetchSong(playlistItem);
        Debug.WriteLine($"Song fetched for {playlistItem.Title} by {playlistItem.Artist}");

        Task.Run(
            (() =>
            {
                var nextPeek = _playQueue.PeekNext();
                Debug.WriteLine($"Async prefretch next song {nextPeek.Title}:");
                _songFetcher.PrefetchSong(nextPeek);
            })
        );
        player.LoadStream(songStream);
        //player.LoadFile(@"C:\Users\butle\Downloads\MUSICDOWNLOADS\05_Unravel.wav");
        Debug.WriteLine("Starting playback");
        player.StartPlayback();
        Console.ReadLine();
        PlayAudio();
    }
}