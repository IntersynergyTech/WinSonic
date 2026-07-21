using System;
using System.ComponentModel.DataAnnotations;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using WinSonic.Resources.Localisation;

namespace WinSonic.Gui.Avalonia.ViewModels.Pages;

public class ServerConfigViewModel : PageViewModelBase
{
    public ServerConfigViewModel()
    {
        ServerUrl = System.Environment.GetEnvironmentVariable("SUBSONIC_URL");
        ServerUsername = System.Environment.GetEnvironmentVariable("SUBSONIC_USERNAME");
        ServerPassword = System.Environment.GetEnvironmentVariable("SUBSONIC_PASSWORD");

        this.WhenAnyValue(x => x.ServerUrl, x => x.ServerUsername, x => x.ServerPassword)
            .Subscribe(_ => UpdateCanNavigateNext());
    }
    
    public override string Title { get; protected set; } = Strings._ServerConfiguration;
    
    public override bool CanNavigateNext { get; protected set; }
    public override bool CanNavigatePrevious { get; protected set; } = true;
    
    private void UpdateCanNavigateNext()
    {
        CanNavigateNext = !string.IsNullOrWhiteSpace(ServerUrl) &&
                          !string.IsNullOrWhiteSpace(ServerUsername) &&
                          !string.IsNullOrWhiteSpace(ServerPassword);
        this.RaisePropertyChanged(nameof(CanNavigateNext));
    }
    
    [Required, Reactive]
    public string? ServerUrl { get; set; }
    [Required, Reactive]
    public string? ServerPassword { get; set; }
    [Required, Reactive]
    public string? ServerUsername { get; set; }
}
