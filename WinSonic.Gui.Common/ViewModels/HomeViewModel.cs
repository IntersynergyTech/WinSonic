using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using WinSonic.Gui.Common.GuiServices;

namespace WinSonic.Gui.Common.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    [ObservableProperty] public partial string Greeting { get; set; } = "Welcome to Avalonia! - Home";
    
    
    [RelayCommand]
    private void SettingsViaNavMessenger()
    {
        NavigationService.NavigateTo(new SettingsViewModel());
    }
    
    [RelayCommand]
    private void SettingsResolvedViaNav()
    {
        var settingsModel = DependencyService.Services.GetService<SettingsViewModel>();
        NavigationService.NavigateTo(settingsModel);
    }
}
