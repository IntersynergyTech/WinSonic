using WinSonic.Gui.Common.ViewModels;

namespace WinSonic.Gui.Common.Messages;

public class NavigationMessage 
{
    public NavigationMessage(ViewModelBase destinationViewModel)
    {
        DestinationViewModel = destinationViewModel;
    }

    public ViewModelBase DestinationViewModel { get; set; }   
}
