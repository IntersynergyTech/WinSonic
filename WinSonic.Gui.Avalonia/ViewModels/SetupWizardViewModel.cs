using System;
using System.Windows.Input;
using ReactiveUI;
using WinSonic.Gui.Avalonia.ViewModels.Pages;
using WinSonic.Resources.Localisation;

namespace WinSonic.Gui.Avalonia.ViewModels;

public class SetupWizardViewModel : ViewModelBase
{
    private readonly PageViewModelBase[] Pages;
    
    private PageViewModelBase _currentPage;

    public PageViewModelBase CurrentPage
    {
        get => _currentPage;
        set => this.RaiseAndSetIfChanged(ref _currentPage, value);
    }

    public string NextButtonText { get; } = Strings._Next;
    public string BackButtonText { get; } = Strings._Back;

    public SetupWizardViewModel()
    {
        Pages = [
            new LandingPageViewModel(),
            new ServerConfigViewModel(),
            new SynchroniseServerViewModel(this),
            new SetupCompleteViewModel()
        ];
        
        _currentPage = Pages[0];
        
        var canNavNext = this.WhenAnyValue(x => x.CurrentPage.CanNavigateNext);
        var canNavPrev = this.WhenAnyValue(x => x.CurrentPage.CanNavigatePrevious);
        
        NextPageCommand = ReactiveCommand.Create(NavigateNextPage, canNavNext);
        PreviousPageCommand = ReactiveCommand.Create(NavigatePreviousPage, canNavPrev);
    }
    
    public ICommand NextPageCommand { get; }

    private void NavigateNextPage()
    {
        var currentIndex = Pages.IndexOf(CurrentPage);
        CurrentPage = Pages[currentIndex + 1];
    }
    
    public ICommand PreviousPageCommand { get; }

    private void NavigatePreviousPage()
    {
        var currentIndex = Pages.IndexOf(CurrentPage);
        CurrentPage = Pages[currentIndex - 1];
    }
}
