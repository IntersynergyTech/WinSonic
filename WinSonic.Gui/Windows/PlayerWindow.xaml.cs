using System.Windows;
using System.Windows.Threading;
using Wpf.Ui.Controls;

namespace WinSonic.Gui.Windows;

public partial class PlayerWindow : FluentWindow
{
    public PlayerWindow()
    {
        InitializeComponent();
    }

    private void PlayerWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        PlayerControls.Init();
        GlobalContext.Dispatcher = Dispatcher.CurrentDispatcher;
    }
}

