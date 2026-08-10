using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WinSonic.Gui.Common.ViewModels;

public abstract class ViewModelBase : ObservableObject
{
}

public abstract partial class PageModelBase : ViewModelBase
{
    [RelayCommand]
    public abstract void OnLoaded();
}
