using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using WinSonic.Gui.Common.Messages;
using WinSonic.Gui.Common.ViewModels;

namespace WinSonic.Gui.Common.GuiServices;

public static class NavigationService
{
    
    public static void NavigateTo(ViewModelBase viewModel)
    {
        WeakReferenceMessenger.Default.Send(new NavigationMessage(viewModel));
    }
    
    public static void NavigateTo<TViewModel>() where TViewModel : ViewModelBase, new()
    {
        var viewModel = DependencyService.Services.GetService<TViewModel>() ?? new TViewModel();
        WeakReferenceMessenger.Default.Send(new NavigationMessage(viewModel));
    }

    private static object? _registeredRecipient = null; 
    
    public static void RegisterNavigationHandler(object recipient, Action<NavigationMessage> action)
    {
        if (_registeredRecipient != null)
        {
            WeakReferenceMessenger.Default.Unregister<NavigationMessage>(_registeredRecipient);
        }
        
        _registeredRecipient = recipient;
        WeakReferenceMessenger.Default.Register<NavigationMessage>(recipient, (r, m) => action(m));
    }
    
}
