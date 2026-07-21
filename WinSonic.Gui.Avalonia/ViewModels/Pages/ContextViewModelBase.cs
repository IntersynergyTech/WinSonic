using WinSonic.Gui.Avalonia.Models;

namespace WinSonic.Gui.Avalonia.ViewModels.Pages;

public class ContextViewModelBase : ViewModelBase
{
    protected readonly GlobalContext Context;

    public ContextViewModelBase(GlobalContext context)
    {
        Context = context;
    }
}
