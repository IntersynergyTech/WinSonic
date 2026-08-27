using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.Extensions.DependencyInjection;
using WinSonic.Data.Sync;
using WinSonic.Gui.Common.GuiServices;
using WinSonic.Gui.Common.ViewModels;

namespace WinSonic.Gui.Xplat.Views;

public partial class SettingsView : ContentPage
{
    private SettingsViewModel? Context => DataContext as SettingsViewModel;

    public SettingsView()
    {
        InitializeComponent();
    }

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        Context?.OnLoaded();
    }

    private void ServerAddressTextBox_LostFocus(object? sender, RoutedEventArgs e)
    {
        Context?.ApplyServerAddressNormalization();
    }

    private async void OnSyncLibraryClicked(object? sender, RoutedEventArgs e)
    {
        var syncManager = DependencyService.Services?.GetService(typeof(SyncManager)) as SyncManager;
        if (syncManager is null)
        {
            return;
        }

        var progressWindow = new SyncProgressWindow();
        progressWindow.Show();

        try
        {
            await syncManager.StartBigSyncAsync();
        }
        finally
        {
            progressWindow.Close();
        }
    }
}
