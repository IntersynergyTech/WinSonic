using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WinSonic.Gui.Common.Components;

public partial class NavigationMenuItemModel : ObservableObject
{
    public NavigationMenuItemModel()
    {

    }

    public NavigationMenuItemModel(ICommand command, string name, NavigationMenuItemActionType actionType = NavigationMenuItemActionType.None, Type? viewModelType = null, object? commandParameter = null )
    {
        Name = name;
        Command = command;
        CommandParameter = commandParameter;
        ActionType = actionType;
        ModelType = viewModelType;
    }
    
    [ObservableProperty]
    public partial string Name { get; set; }
    [ObservableProperty]
    public partial NavigationMenuItemActionType ActionType { get; set; }

    [ObservableProperty]
    public partial Type? ModelType { get; set; }
    
    [ObservableProperty]
    public partial object CommandParameter { get; set; }

    [ObservableProperty]
    public partial ICommand Command { get; set; }
}

public enum NavigationMenuItemActionType
{
    None,
    Home,
    Settings,
    Queue,
    Playlists,
    Artists,
    Albums,
    Tracks,
    Favourites,
    Search,
    OpenPlaylist,
    OpenArtist,
    OpenAlbum,
}
