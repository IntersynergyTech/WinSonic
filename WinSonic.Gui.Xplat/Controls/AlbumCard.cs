using Avalonia;
using Avalonia.Controls.Primitives;
using Microsoft.Extensions.DependencyInjection;
using WinSonic.Gui.Common.GuiServices;
using WinSonic.Gui.Common.ViewModels.Components;

namespace WinSonic.Gui.Xplat.Controls;

public class AlbumCard : TemplatedControl
{
    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string CoverArtId
    {
        get => GetValue(CoverArtIdProperty);
        set
        {
            SetValue(CoverArtIdProperty, value); 
            CoverArtViewModel.CoverArtId = value;
        }
    }

    public string Artist
    {
        get => GetValue(ArtistProperty);
        set => SetValue(ArtistProperty, value);
    }

    public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<AlbumCard, string>(nameof(Title));

    public static readonly StyledProperty<string> CoverArtIdProperty =
        AvaloniaProperty.Register<AlbumCard, string>(nameof(CoverArtId));

    public static readonly StyledProperty<string> ArtistProperty =
        AvaloniaProperty.Register<AlbumCard, string>(nameof(Artist));

    public CoverArtViewModel CoverArtViewModel { get; set; }
    
    public AlbumCard()
    {
        CoverArtViewModel = DependencyService.Services.GetService<CoverArtViewModel>();
    }
}
