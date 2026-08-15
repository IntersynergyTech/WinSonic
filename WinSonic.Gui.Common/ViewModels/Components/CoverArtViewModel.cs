using CommunityToolkit.Mvvm.ComponentModel;
using WinSonic.Data.DbModels;
using WinSonic.Service.Artwork;

namespace WinSonic.Gui.Common.ViewModels.Components;

public partial class CoverArtViewModel : ViewModelBase
{
    private readonly IArtworkService _artworkService;

    public CoverArtViewModel(IArtworkService artworkService)
    {
        _artworkService = artworkService;
    }

    [ObservableProperty] public partial string? CoverArtId { get; set; }
    /// <summary>
    /// This specifies the requested image dimensions for the artwork. It *does not* specify how large it will actually be displayed. Leave it null to use full res artwork.
    /// </summary>
    [ObservableProperty]
    public partial int? Dimensions { get; set; }

    /// <summary>
    /// Reserved for the UI implementation to bind the parsed image data from the source.
    /// </summary>
    [ObservableProperty]
    public partial object? CoverArtSourceData { get; set; }
}
