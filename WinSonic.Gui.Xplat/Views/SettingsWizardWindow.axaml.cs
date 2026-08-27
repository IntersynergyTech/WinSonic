using Avalonia.Controls;
using Avalonia.Interactivity;
using WinSonic.Gui.Common.ViewModels;

namespace WinSonic.Gui.Xplat.Views;

public partial class SettingsWizardWindow : Window
{
    private SettingsWizardViewModel? Context => DataContext as SettingsWizardViewModel;

    public SettingsWizardWindow()
    {
        InitializeComponent();
    }

    private void ServerAddressTextBox_LostFocus(object? sender, RoutedEventArgs e)
    {
        Context?.ApplyServerAddressNormalization();
    }
}
