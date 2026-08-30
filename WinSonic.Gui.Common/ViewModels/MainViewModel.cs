using CommunityToolkit.Mvvm.ComponentModel;
using WinSonic.Gui.Common.GuiServices;

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
