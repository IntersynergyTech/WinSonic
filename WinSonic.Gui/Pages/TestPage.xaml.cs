using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using WinSonic.Core;
using WinSonic.Core.Models;
using WinSonic.Data.Sync.Mappers;
using WinSonic.Service.Playlist;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Gui.Pages;

public partial class TestPage : Page
{
    public ObservableCollection<PlaylistInfo> Playlists { get; } = new ObservableCollection<PlaylistInfo>();
    public ObservableCollection<Song> Songs { get; } = new ObservableCollection<Song>();

    public ObservableCollection<Song> SongsCache { get; set; } = new ObservableCollection<Song>();

    public PlaylistInfo? SelectedPlaylist { get; set; }

    public TestPage()
    {
        DataContext = this;
        InitializeComponent();
    }

    private void LoadPlaylists_Click(object sender, RoutedEventArgs e)
    {
        var playlistsResponse = GlobalContext.Subsonic.Playlists.GetPlaylists();
        var playlists = playlistsResponse.SubsonicResponse.GetGetPlaylistsSuccessResponse().Playlists.Playlist;
        Playlists.Clear();

        foreach (var playlist in playlists)
        {
            Playlists.Add(PlaylistMappers.ApiToPlaylistInfo(playlist));
        }
    }

    private void PlaylistGrid_Selected(object sender, SelectionChangedEventArgs e)
    {
        var selectedPlaylist = PlaylistGrid.SelectedItem as PlaylistInfo;
        SelectedPlaylist = selectedPlaylist;
        if (selectedPlaylist == null) return;

        var fullPlaylistResponse = GlobalContext.Subsonic.Playlists.GetPlaylist(selectedPlaylist.Id);
        var fullPlayList = fullPlaylistResponse.SubsonicResponse.GetGetPlaylistSuccessResponse().Playlist.ApiToPlaylistFull();
        Songs.Clear();

        foreach (var song in fullPlayList.Entries)
        {
            Songs.Add(song);
        }
    }

    private void SongsGrid_Selected(object sender, SelectionChangedEventArgs e)
    {
        var selectedSong = SongsGrid.SelectedItem as Song;
        if (selectedSong == null) return;

        var songStream = GlobalContext.SongFetcher.FetchSong(selectedSong);
        GlobalContext.AudioPlayer.LoadStream(songStream, selectedSong);

        GlobalContext.AudioPlayer.Play();
    }

    private void Stop_Click(object sender, RoutedEventArgs e)
    {
        GlobalContext.AudioPlayer.Stop();
    }

    private void PlayPlaylistButton(object sender, RoutedEventArgs e)
    {
        GlobalContext.AutoPlaybackManager.Queue.ResetAndEnqueueFromSource(Songs.ToList(), true);
        GlobalContext.AutoPlaybackManager.StartPlayback();
    }

    private void RunBigSyncClicked(object sender, RoutedEventArgs e)
    {
        GlobalContext.SyncManager.StartBigSync();
    }

    private async void StopBigSyncClicked(object sender, RoutedEventArgs e)
    {
        await GlobalContext.SyncManager.CancelAll();
    }

    private void SongsCacheGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedSong = SongsCacheGrid.SelectedItem as Song;
        if (selectedSong == null) return;

        var songStream = GlobalContext.SongFetcher.FetchSong(selectedSong);
        GlobalContext.AudioPlayer.LoadStream(songStream, selectedSong);

        GlobalContext.AudioPlayer.Play();
    }

    private void TestPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        Task.Run(() =>
            {
                var db = GlobalContext.DbContextFactory.Create();
                var allSongs = db.Songs.Include(x => x.Album).Include(x => x.Artist).ToList();
                var converted = allSongs.ConvertList(ServiceMappers.ToSong);

                GlobalContext.InvokeOnUi(() =>
                    {
                        foreach (var song in converted)
                        {
                            SongsCache.Add(song);
                        }
                    }
                );
            }
        );
    }
}
