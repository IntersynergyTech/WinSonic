using System.Diagnostics;
using WinSonic.Core;
using WinSonic.Core.Enums;
using WinSonic.Core.Models;
using WinSonic.Playback;
using WinSonic.Player;
using WinSonic.Subsonic.Helpers;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        _storageManager = new StorageManager();
        _storageManager.EnsureDirectoriesExist();
        _player = new SoundFlowMultiPlayer();

        ConnectToServer();
        PlayAudio();
    }

    public static SoundFlowMultiPlayer _player { get; set; }
    public static PlayQueue _playQueue { get; set; }
    public static StorageManager _storageManager { get; set; }
    public static SongFetcher _songFetcher { get; set; }
    public static AutoPlaybackManager _autoPlaybackManager { get; set; }

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
            Console.WriteLine(
                $"[{index++}]: [{playlist.Id}] {playlist.Name} (by {playlist.Owner}, {playlist.SongCount} songs, {TimeSpan.FromSeconds(playlist.Duration).ToString(@"hh\:mm\:ss")})"
            );
        }

        Console.WriteLine("Enter playlist number:");
        var playlistNumber = Convert.ToInt32(Console.ReadLine());

        var fullPlaylistResponse = client.Playlists.GetPlaylist(playlists[playlistNumber].Id);

        var fullPlaylist = fullPlaylistResponse.SubsonicResponse.GetGetPlaylistSuccessResponse().Playlist;

        var playlistObject = fullPlaylist.ToPlaylist();

        _playQueue = new PlayQueue();

        _songFetcher = new SongFetcher(client, _storageManager);

        _autoPlaybackManager = new AutoPlaybackManager(_playQueue, _songFetcher, _player);

        _autoPlaybackManager.Queue.ResetAndEnqueueFromSource(playlistObject.Entries, true);

        Console.WriteLine($"Playing {fullPlaylist.Name}:");

        foreach (var item in _playQueue.EnumerateQueue())
        {
            Console.WriteLine($"[{item.Id}] {item.Title} (by {item.Artist}, {item.Duration.ToString(@"mm\:ss")})");
        }

        Console.WriteLine("Starting Playback. (hopefully)");
    }

    static void PlayAudio()
    {
        Console.WriteLine("Playing with APM. Press [x] to exit [n] to skip [+] volume up [-] volume down [p] pause/play ");
        _autoPlaybackManager.NowPlayingChanged += AutoPlaybackManagerOnNowPlayingChanged;
        _autoPlaybackManager.StartPlayback();
        while (true)
        {
            var input = Console.ReadKey();

            if (input.Key == ConsoleKey.X)
            {
                _player.Stop();
                break;
            }
            
            switch (input.Key)
            {
                case ConsoleKey.N:
                    _autoPlaybackManager.NextSong();
                    break;
                case ConsoleKey.OemPlus:
                    _player.Volume = Math.Min(2f, _player.Volume + 0.05f);
                    Console.WriteLine($"Volume: {_player.Volume:P2}");
                    break;
                case ConsoleKey.OemMinus:
                    _player.Volume = Math.Max(0f, _player.Volume - 0.05f);
                    Console.WriteLine($"Volume: {_player.Volume:P2}");
                    break;
                case ConsoleKey.P:
                    if (_player.PlaybackState == PlaybackState.Playing)
                    {
                        _player.Pause();
                    }
                    else
                    {
                        _player.Play();
                    }
                    break;
            }
        }
        
        /*
        var playlistItem = _playQueue.Dequeue();
        Console.WriteLine($"Now Playing: {playlistItem.Title} by {playlistItem.Artist}");
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
        _player.LoadStream(songStream);
        //_player.LoadFile(@"C:\Users\butle\Downloads\MUSICDOWNLOADS\05_Unravel.wav");
        Debug.WriteLine("Starting playback");
        _player.Play();
        Console.ReadLine();
        PlayAudio();*/
    }

    private static void AutoPlaybackManagerOnNowPlayingChanged(object? sender, Song? e)
    {
        if (e != null)
        {
            Console.WriteLine($"Now Playing: {e.Title} by {e.Artist} [{e.Duration}]");
        }
    }
}
