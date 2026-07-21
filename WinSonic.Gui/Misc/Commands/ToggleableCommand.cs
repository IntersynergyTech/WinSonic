using System.Windows.Input;
using System.Windows.Threading;

namespace WinSonic.Gui.Misc.Commands;

public class ToggleableCommand : ICommand
{
    private bool _executable;
    public bool Executable
    {
        get => _executable;
        set
        {
            _executable = value;
            GlobalContext.InvokeOnUi(() => CanExecuteChanged?.Invoke(this, EventArgs.Empty));
        }
    }

    public bool CanExecute(object? parameter)
    {
        return Executable;
    }

    public void Execute(object? parameter)
    {
    }

    public event EventHandler? CanExecuteChanged;
}
