using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using WinSonic.Gui.Common.GuiServices;
using WinSonic.Service.Playlist;

namespace WinSonic.Gui.Common.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] public partial string Greeting { get; set; } = "Welcome to Avalonia! - Main";

    [ObservableProperty]
    public partial ViewModelBase CurrentPageModel { get; set; }

    public MainViewModel()
    {
        NavigationService.RegisterNavigationHandler(
            this,
            async (message) =>
            {
                CurrentPageModel = message.DestinationViewModel;
            }
        );
    }
}
