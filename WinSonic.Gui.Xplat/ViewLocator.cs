using System;
using System.Diagnostics.CodeAnalysis;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using WinSonic.Gui.Common.ViewModels;

namespace WinSonic.Gui.Xplat;

/// <summary>
/// Given a view model, returns the corresponding view if possible.
/// </summary>
[RequiresUnreferencedCode(
    "Default implementation of ViewLocator involves reflection which may be trimmed away.",
    Url = "https://docs.avaloniaui.net/docs/concepts/view-locator"
)]
public class ViewLocator : IDataTemplate
{
    private const string ViewModelNamespace = "WinSonic.Gui.Common.ViewModels";
    private const string ViewNamespace = "WinSonic.Gui.Xplat.Views";
    
    private const string ViewModelSuffix = "ViewModel";
    private const string ViewSuffix = "View";

    public Control? Build(object? param)
    {
        if (param is null) return null;

        var name = param.GetType().FullName!.Replace(ViewModelNamespace, ViewNamespace, StringComparison.Ordinal);
        name = name.Replace(ViewModelSuffix, ViewSuffix, StringComparison.Ordinal);
        var type = Type.GetType(name);

        if (type != null)
        {
            return (Control) Activator.CreateInstance(type)!;
        }

        return new TextBlock { Text = "Not Found: " + name };
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}
