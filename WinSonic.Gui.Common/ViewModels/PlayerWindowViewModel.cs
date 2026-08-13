using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using WinSonic.Core.Models;
using WinSonic.Gui.Common.Components;
using WinSonic.Gui.Common.GuiServices;
using WinSonic.Gui.Common.ViewModels.BrowsePages;
using WinSonic.Gui.Common.ViewModels.Components;
using WinSonic.Gui.Common.ViewModels.DetailPages;
using WinSonic.Resources.Localisation;
using WinSonic.Service.Playlist;

namespace WinSonic.Gui.Common.ViewModels;

public partial class PlayerWindowViewModel : PageModelBase
{
    private readonly IPlaylistService? _playlistService;

    NavigationMenuItemModel[] BaseNavigationMenuItems() =>
        new NavigationMenuItemModel[]
        {
            new (GenericNavigateCommand, Strings._NowPlaying, NavigationMenuItemActionType.Home),
            new (
                GenericNavigateCommand,
                Strings._Albums,
                NavigationMenuItemActionType.None,
                typeof(AlbumsViewModel)
            ),
            new (
                GenericNavigateCommand,
                Strings._Playlists,
                NavigationMenuItemActionType.None,
                typeof(PlaylistsViewModel)
            ),
            new (
                GenericNavigateCommand,
                Strings._Artists,
                NavigationMenuItemActionType.None,
                typeof(ArtistsViewModel)
            ),
            new (command: null, string.Empty, isSeperator: true),
            new (command: null, Strings._Playlists, isHeader: true),
        };

    NavigationMenuItemModel[] BaseNavigationMenuFooterItems() =>
    [
        new (GenericNavigateCommand, Strings._Settings, NavigationMenuItemActionType.Settings),
        new (GenericNavigateCommand, Strings._TestPage, NavigationMenuItemActionType.None, typeof(TestViewModel)),
    ];

    [ObservableProperty] public partial ViewModelBase CurrentViewModel { get; set; }

    [ObservableProperty]
    public partial ObservableCollection<NavigationMenuItemModel> NavigationMenuItems { get; set; } = new ();

    [ObservableProperty]
    public partial ObservableCollection<NavigationMenuItemModel> NavigationMenuFooterItems { get; set; } = new ();

    [ObservableProperty] public partial PlaybackControlsViewModel PlaybackControls { get; set; }

    public PlayerWindowViewModel()
    {
        Init();
    }

    public PlayerWindowViewModel(IPlaylistService playlistService)
    {
        _playlistService = playlistService;
        Init();
    }

    private void Init()
    {
        NavigationService.RegisterNavigationHandler(
            this,
            async (message) => { CurrentViewModel = message.DestinationViewModel; }
        );
    }

    [RelayCommand]
    public async Task GenericNavigate(NavigationMenuItemModel menuItem)
    {
        if (menuItem.ActionType != NavigationMenuItemActionType.None)
        {
            var viewModel = ResolveModelFromActionType(menuItem.ActionType);
            CurrentViewModel = viewModel;
        }
        else
        {
            try
            {
                var viewModel = DependencyService.Services.GetService(menuItem.ModelType!) as ViewModelBase;

                if (viewModel != null)
                {
                    CurrentViewModel = viewModel;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }

    [RelayCommand]
    public async Task NavigatePlaylist(NavigationMenuItemModel menuItem)
    {
        var viewModel = DependencyService.Services.GetService<SinglePlaylistViewModel>();

        if (viewModel != null)
        {
            viewModel.SetPlaylist(menuItem.CommandParameter as PlaylistInfo);

            CurrentViewModel = viewModel;
        }
    }

    private ViewModelBase? ResolveModelFromActionType(NavigationMenuItemActionType actionType)
    {
        return actionType switch
        {
            NavigationMenuItemActionType.Home => DependencyService.Services.GetService<HomeViewModel>(),
            NavigationMenuItemActionType.Settings => DependencyService.Services.GetService<SettingsViewModel>(),
            _ => throw new ArgumentOutOfRangeException(nameof(actionType), actionType, null)
        };
    }

    public override async void OnLoaded()
    {
        NavigationMenuItems = new ObservableCollection<NavigationMenuItemModel>(BaseNavigationMenuItems());
        NavigationMenuFooterItems = new ObservableCollection<NavigationMenuItemModel>(BaseNavigationMenuFooterItems());
        PlaybackControls = DependencyService.Services.GetService<PlaybackControlsViewModel>();

        var playlists = await _playlistService?.GetPlaylistsAsync();

        if (playlists != null)
        {
            foreach (var playlist in playlists)
            {
                NavigationMenuItems.Add(
                    new NavigationMenuItemModel(
                        NavigatePlaylistCommand,
                        playlist.Name,
                        NavigationMenuItemActionType.None,
                        typeof(SinglePlaylistViewModel),
                        playlist
                    )
                );
            }
        }
    }
}
