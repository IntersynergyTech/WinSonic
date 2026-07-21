using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WinSonic.Core.Models;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Gui.Pages;

public partial class TestPage : Page
{
    public ObservableCollection<PlaylistInfo> Playlists { get; } = new ObservableCollection<PlaylistInfo>();
    public ObservableCollection<Song> Songs { get; } = new ObservableCollection<Song>();
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
            Playlists.Add(playlist.ToPlaylist());
        }
    }

    private void PlaylistGrid_Selected(object sender, SelectionChangedEventArgs e)
    {
        var selectedPlaylist = PlaylistGrid.SelectedItem as PlaylistInfo;
        SelectedPlaylist = selectedPlaylist;
        if (selectedPlaylist == null) return;
        
        var fullPlaylistResponse = GlobalContext.Subsonic.Playlists.GetPlaylist(selectedPlaylist.Id);
        var fullPlayList = fullPlaylistResponse.SubsonicResponse.GetGetPlaylistSuccessResponse().Playlist.ToPlaylist();
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
}

