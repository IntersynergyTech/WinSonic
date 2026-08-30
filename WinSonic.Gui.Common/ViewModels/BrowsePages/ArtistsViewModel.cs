using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using WinSonic.Core.Models;
using WinSonic.Gui.Common.GuiServices;
using WinSonic.Gui.Common.ViewModels.DetailPages;
using WinSonic.Service.Artist;

namespace WinSonic.Gui.Common.ViewModels.BrowsePages;

public partial class ArtistsViewModel : PageModelBase
{
    private readonly IArtistService _artistService;

    [ObservableProperty] public partial ObservableCollection<Artist> Artists { get; set; } = new();

    [ObservableProperty, NotifyCanExecuteChangedFor(nameof(NavigateToArtistDetailCommand))]
    public partial Artist? SelectedArtist { get; set; }

    [RelayCommand(CanExecute = nameof(ArtistIsSelected))]
    public async Task NavigateToArtistDetailAsync()
    {
        if (SelectedArtist == null) return;

        var detailViewModel = DependencyService.Services.GetService<SingleArtistViewModel>();
        detailViewModel!.SetArtist(SelectedArtist);
        NavigationService.NavigateTo(detailViewModel);
    }

    private bool ArtistIsSelected() => SelectedArtist != null;

    public ArtistsViewModel(IArtistService artistService)
    {
        _artistService = artistService;
    }

    public override void OnLoaded()
    {
        Task.Run(async () =>
            {
                var artists = await _artistService.GetArtistsAsync();
                Artists = new ObservableCollection<Artist>(artists.OrderBy(a => a.SortName));
            }
        );
    }
}
