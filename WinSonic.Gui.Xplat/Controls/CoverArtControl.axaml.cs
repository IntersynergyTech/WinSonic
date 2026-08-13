using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.Extensions.DependencyInjection;
using WinSonic.Gui.Common.GuiServices;
using WinSonic.Gui.Common.ViewModels.Components;

namespace WinSonic.Gui.Xplat.Controls;

public partial class CoverArtControl : UserControl
{
    public CoverArtViewModel _viewModel;
    
    public CoverArtViewModel ViewModel
    {
        get => _viewModel;
        set => SetAndRaise(ViewModelProperty, ref _viewModel, value);
    }
    
    public string CoverArt { get; set; }
    
    public CoverArtControl()
    {
        DataContext = this;
        InitializeComponent();
    }

    public string CoverArtId
    {
        get => CoverArt;
        set => CoverArt = value;
    }

    public static readonly DirectProperty<CoverArtControl, string> CoverArtIdProperty =
        AvaloniaProperty.RegisterDirect<CoverArtControl, string>(
            nameof(CoverArtId),
            o => o.CoverArtId,
            (o, v) => o.CoverArtId = v
        );
    
    public static readonly DirectProperty<CoverArtControl, CoverArtViewModel> ViewModelProperty =
        AvaloniaProperty.RegisterDirect<CoverArtControl, CoverArtViewModel>(
            nameof(ViewModel),
            o => o.ViewModel,
            (o, v) => o.ViewModel = v
        );

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        //ViewModel.OnLoaded();
        var vm = DependencyService.Services.GetService<CoverArtViewModel>()!;
        vm.CoverArtId = CoverArtId;
        SetAndRaise(ViewModelProperty, ref _viewModel, vm);
    }
}
