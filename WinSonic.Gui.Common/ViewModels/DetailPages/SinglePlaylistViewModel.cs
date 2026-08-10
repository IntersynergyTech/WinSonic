using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using WinSonic.Core.Models;
using WinSonic.Service.Playlist;

namespace WinSonic.Gui.Common.ViewModels.DetailPages;

public partial class SinglePlaylistViewModel : PageModelBase
{
    private readonly IPlaylistService _playlistService;

    public void SetPlaylist(PlaylistInfo playlistInfo)
    {
        PlaylistInfo = playlistInfo;
        // Implement logic to load a single playlist using the _playlistService
        Console.WriteLine($"Loading playlist: {playlistInfo.Name}");
    }

    public SinglePlaylistViewModel(IPlaylistService playlistService)
    {
        _playlistService = playlistService;
    }

    public override void OnLoaded()
    {
        Console.WriteLine("SinglePlaylistViewModel OnLoadCommand called");
        Task.Run(async () =>
        {
            await Task.Delay(1000); // Simulate delay
            if (PlaylistInfo != null)
            {
                var fullPlaylist = await _playlistService.GetPlaylistByIdAsync(PlaylistInfo.Id);
                Songs = new ObservableCollection<Song>(fullPlaylist.Entries);
            }
        });
    }

    [ObservableProperty] public partial PlaylistInfo PlaylistInfo { get; set; }
    [ObservableProperty] public partial ObservableCollection<Song> Songs { get; set; } = new ();
}
