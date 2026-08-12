using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
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
    NavigationMenuItemModel[] BaseNavigationMenuItems() =>
        new NavigationMenuItemModel[]
        {
            new (GenericNavigateCommand, Strings._Home, NavigationMenuItemActionType.Home),
            new (
                GenericNavigateCommand,
                Strings._TestPage,
                NavigationMenuItemActionType.None,
                typeof(TestViewModel)
            ),
            new (
                GenericNavigateCommand,
                Strings._Playlists,
                NavigationMenuItemActionType.None,
                typeof(PlaylistsViewModel)
            ),
            new (GenericNavigateCommand, Strings._Settings, NavigationMenuItemActionType.Settings)
        };

    [ObservableProperty] public partial ViewModelBase CurrentViewModel { get; set; }

    [ObservableProperty]
    public partial ObservableCollection<NavigationMenuItemModel> NavigationMenuItems { get; set; } = new ();

    [ObservableProperty] public partial PlaybackControlsViewModel PlaybackControls { get; set; }

    public PlayerWindowViewModel()
    {
        Init();
    }

    public PlayerWindowViewModel(IPlaylistService playlistService)
    {
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

    public async Task NavigatePlaylist(NavigationMenuItemModel menuItem)
    {
        var viewModel = DependencyService.Services.GetService<SinglePlaylistViewModel>();

        if (viewModel != null)
        {
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

    public override void OnLoaded()
    {
        NavigationMenuItems = new ObservableCollection<NavigationMenuItemModel>(BaseNavigationMenuItems());
        PlaybackControls = DependencyService.Services.GetService<PlaybackControlsViewModel>();
    }
}
