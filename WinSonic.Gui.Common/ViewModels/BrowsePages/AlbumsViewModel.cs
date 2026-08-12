using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using WinSonic.Core.Models;
using WinSonic.Gui.Common.GuiServices;
using WinSonic.Gui.Common.ViewModels.DetailPages;
using WinSonic.Service.Album;

namespace WinSonic.Gui.Common.ViewModels.BrowsePages;

public partial class AlbumsViewModel : PageModelBase
{
    private readonly IAlbumService _albumService;

    [ObservableProperty] public partial ObservableCollection<AlbumInfo> Albums { get; set; } = new();

    [ObservableProperty, NotifyCanExecuteChangedFor(nameof(NavigateToAlbumDetailCommand))]
    public partial AlbumInfo? SelectedAlbum { get; set; }

    [RelayCommand(CanExecute = nameof(AlbumIsSelected))]
    public async Task NavigateToAlbumDetailAsync()
    {
        if (SelectedAlbum == null) return;

        var detailViewModel = DependencyService.Services.GetService<SingleAlbumViewModel>();
        detailViewModel!.SetAlbum(SelectedAlbum);
        NavigationService.NavigateTo(detailViewModel);
    }

    private bool AlbumIsSelected() => SelectedAlbum != null;

    public AlbumsViewModel(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    public override void OnLoaded()
    {
        Task.Run(async () =>
            {
                var albums = await _albumService.GetAlbumsAsync();
                Albums = new ObservableCollection<AlbumInfo>(albums.OrderBy(a => a.SortTitle ?? a.Title));
            }
        );
    }
}
