using System;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Microsoft.Extensions.DependencyInjection;
using WinSonic.Gui.Common.GuiServices;
using WinSonic.Gui.Common.ViewModels.Components;
using WinSonic.Service.Artwork;

namespace WinSonic.Gui.Xplat.Views.Components;

// THIS WAS SUCH A PAIN IN THE ARSE

public partial class CoverArtView : UserControl
{
    public CoverArtViewModel Context => (CoverArtViewModel) DataContext!;
    private readonly IArtworkService _artworkService;

    private CancellationTokenSource _imageLoadCancellationSource = new ();

    public CoverArtView()
    {
        _artworkService = DependencyService.Services.GetService<IArtworkService>();
        InitializeComponent();
    }

    private string? _currentCoverArtId;

    private void UpdateCoverArtImage()
    {
        // Sometimes this fires too early? idk
        if (Context is null) return;
        
        Context.CoverArtSourceData = null;
        var newCoverArtId = Context.CoverArtId;

        if (_currentCoverArtId == newCoverArtId) return;

        _currentCoverArtId = newCoverArtId;

        Console.WriteLine($"Updating cover art image for ID: {newCoverArtId}");

        if (_artworkService is null || String.IsNullOrEmpty(newCoverArtId))
        {
            Console.WriteLine("Artwork service or CoverArtId is null, skipping image update.");
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
                        var stream = await _artworkService.GetArtworkAsync(
                            newCoverArtId,
                            cancellationToken: cancellationToken
                        );

                        try
                        {
                            if (!cancellationToken.IsCancellationRequested)
                            {
                                var bitmap = new Bitmap(stream);

                                Dispatcher.Post(() =>
                                    {
                                        if (!cancellationToken.IsCancellationRequested)
                                        {
                                            Context.CoverArtSourceData = bitmap;
                                        }
                                    }
                                );
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
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

