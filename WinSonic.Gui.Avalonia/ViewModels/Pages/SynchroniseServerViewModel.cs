using System;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using WinSonic.Resources.Localisation;

namespace WinSonic.Gui.Avalonia.ViewModels.Pages;

public class SynchroniseServerViewModel : PageViewModelBase, IActivatableViewModel
{
    private readonly SetupWizardViewModel _setupWizardViewModel;
    
    public SynchroniseServerViewModel(SetupWizardViewModel parentViewModel)
    {
        Console.WriteLine($"SynchroniseServerViewModel created with parent: {parentViewModel}");
        Activator = new ViewModelActivator();
        _setupWizardViewModel = parentViewModel;

    }
    
    
    
    public override string Title { get; protected set; } = Strings._SyncServerTitle;
    public string Body { get; } = Strings._SyncServerSubtitle;
    [Reactive] 
    public string Status { get; set; } = "preparing";
    public override bool CanNavigateNext { get; protected set; } = false;
    public override bool CanNavigatePrevious { get; protected set; } = true;
    public ViewModelActivator Activator { get; }
}
