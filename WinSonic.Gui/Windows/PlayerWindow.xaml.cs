using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WinSonic.Core.Models;
using WinSonic.Gui.Pages;
using WinSonic.Resources.Localisation;
using WinSonic.Service.Playlist;
using Wpf.Ui;
using Wpf.Ui.Abstractions;
using Wpf.Ui.Controls;

namespace WinSonic.Gui.Windows;

public partial class PlayerWindow : FluentWindow
{
    private readonly INavigationViewPageProvider _pageProvider;
    private readonly INavigationService _navigationService;
    private readonly IPlaylistService _playlistService;
    private readonly ILogger<PlayerWindow> _logger;

    public ObservableCollection<Control> SidebarPlaylists { get; set; } = new ();

    public Control[] DefaultMenuItems =
    [
        new NavigationViewItem { Content = "Test Wee", TargetPageType = typeof(TestPage), TargetPageTag = "Home" },
        new NavigationViewItem { Content = "Service test", TargetPageType = typeof(ServiceTest), },
        new NavigationViewItemSeparator(),
        new NavigationViewItem { Content = Strings._Playlists, TargetPageType = typeof(ServiceTest), }
    ];

    public PlayerWindow(
        IPlaylistService playlistService,
        INavigationViewPageProvider pageProvider,
        ILogger<PlayerWindow> logger,
        INavigationService navigationService
    )
    {
        DataContext = this;
        _pageProvider = pageProvider;
        _playlistService = playlistService;
        _logger = logger;
        _navigationService = navigationService;
        InitializeComponent();
    }

    private async void PlayerWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        PlayerControls.Init();
        GlobalContext.Dispatcher = Dispatcher.CurrentDispatcher;

        MainNavigationView.SetServiceProvider(App.ServiceProvider);
        var pageProvider = App.ServiceProvider.GetRequiredService<INavigationViewPageProvider>();
        MainNavigationView.SetPageProviderService(pageProvider);
        _navigationService.SetNavigationControl(MainNavigationView);
        await PopulateSidebar();
    }

    private async Task PopulateSidebar()
    {
        SidebarPlaylists.Clear();

        foreach (var defaultItem in DefaultMenuItems)
        {
            SidebarPlaylists.Add(defaultItem);
        }

        var playlists = await _playlistService.GetPlaylistsAsync();

        foreach (var playlist in playlists)
        {
            var menuItem = new NavigationViewItem();
            menuItem.Content = playlist.Name;
            menuItem.Tag = playlist;
            menuItem.TargetPageType = typeof(PlaylistPage);
            menuItem.CommandParameter = playlist;
            menuItem.TargetPageTag = $"PL_{playlist.Id}";
            SidebarPlaylists.Add(menuItem);
        }

        MainNavigationView.MenuItemsSource = SidebarPlaylists;
    }

    private void MainNavigationView_OnNavigated(NavigationView sender, NavigatedEventArgs args)
    {
        _logger.LogDebug($"Navigated {args.Page}|{args.Source}|{args.OriginalSource}|{args.RoutedEvent}");
    }

    private void MainNavigationView_OnNavigating(NavigationView sender, NavigatingCancelEventArgs args)
    {
        _logger.LogDebug($"Navigating {args.Page}|{args.Source}|{args.OriginalSource}|{args.RoutedEvent}");

        if (args.Page is PlaylistPage playlistPage)
        {
            if (args.Source == MainNavigationView)
            {
                var selected = MainNavigationView.SelectedItem as NavigationViewItem;
                var tag = selected?.Tag;

                if (tag is PlaylistInfo playlistInfo)
                {
                    playlistPage.LoadPlaylist(playlistInfo);
                }
            }
        }
    }

    private void MainNavigationView_OnSelectionChanged(NavigationView sender, RoutedEventArgs args)
    {
        _logger.LogDebug($"Selection changed {args.Source}|{args.OriginalSource}|{args.RoutedEvent}");
    }
}
