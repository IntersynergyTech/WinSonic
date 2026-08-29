using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WinSonic.Gui.Common.GuiServices;
using WinSonic.Gui.Common.ViewModels.Components;
using WinSonic.Service.Artwork;

namespace WinSonic.Gui.Xplat.Views.Components;

// THIS WAS SUCH A PAIN IN THE ARSE

public partial class CoverArtView : UserControl
{
    public CoverArtViewModel Context => (CoverArtViewModel) DataContext!;
    private readonly IArtworkService _artworkService;
    private readonly ILogger<CoverArtView> _logger;

    private CancellationTokenSource _imageLoadCancellationSource = new ();

    public CoverArtView()
    {
        _artworkService = DependencyService.Services.GetService<IArtworkService>();
        _logger = DependencyService.Services.GetService<ILogger<CoverArtView>>();
        InitializeComponent();
    }

    private string? _currentCoverArtId;

    private void UpdateCoverArtImage()
    {
        // Sometimes this fires too early? idk
        if (Context is null) return;

        Context.CoverArtSourceData = null;
        Disc.IsVisible = true;
        var newCoverArtId = Context.CoverArtId;
        var newCoverArtDimensions = Context.Dimensions;

        if (_currentCoverArtId == newCoverArtId) return;

        _currentCoverArtId = newCoverArtId;

        _logger.LogDebug("Updating cover art image for ID: {newCoverArtId}", newCoverArtId);

        if (_artworkService is null || String.IsNullOrEmpty(newCoverArtId))
        {
            _logger.LogTrace("Artwork service or CoverArtId is null, skipping image update.");
            return;
        }

        _imageLoadCancellationSource.Cancel();
        _imageLoadCancellationSource = new CancellationTokenSource();
        var cancellationToken = _imageLoadCancellationSource.Token;

        Task.Run(
            async () =>
            {
                if (newCoverArtId is not null)
                {
                    if (_artworkService is not null)
                    {
                        Stream stream = null;
                        if (newCoverArtDimensions is not null)
                        {
                            stream = await _artworkService.GetArtworkWithDimensionAsync(
                                newCoverArtId,
                                newCoverArtDimensions!.Value,
                                acceptAnyCached: false,
                                cancellationToken: cancellationToken
                            );
                        }
                        else
                        {
                            stream = await _artworkService.GetArtworkAsync(
                                newCoverArtId,
                                acceptAnyCached: false,
                                cancellationToken: cancellationToken
                            );
                        }

                        try
                        {
                            if (!cancellationToken.IsCancellationRequested)
                            {
                                var bitmap = new Bitmap(stream);

                                Dispatcher.Post(() =>
                                    {
                                        if (!cancellationToken.IsCancellationRequested)
                                        {   
                                            Disc.IsVisible = false;
                                            Context.CoverArtSourceData = bitmap;
                                        }
                                    }
                                );
                            }
                        }
                        catch (Exception e)
                        {
                            _logger.LogError(e, "Error updating cover art image.");
                        }
                    }
                }
            },
            cancellationToken
        );
    }

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        UpdateCoverArtImage();

        Context.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(Context.CoverArtId) || args.PropertyName == nameof(DataContext))
            {
                Dispatcher.Post(UpdateCoverArtImage);
            }
        };
    }
}
