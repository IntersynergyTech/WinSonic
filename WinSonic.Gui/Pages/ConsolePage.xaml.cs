using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WinSonic.Gui.Pages;

public partial class ConsolePage : Page
{
    public bool EnableWriting { get; set; }
    
    public ConsolePage()
    {
        InitializeComponent();
    }

    private void ConsolePage_OnLoaded(object sender, RoutedEventArgs e)
    {
        Console.SetOut(new TextBoxStreamWriter(this));
    }
}

public class TextBoxStreamWriter : TextWriter
{
    private readonly ConsolePage _page;
    Wpf.Ui.Controls.TextBox _output = null;
    
    public TextBoxStreamWriter(ConsolePage page)
    {
        _page = page;
        _output = page.ConsoleOutput;
    }
    
    public override void Write(char value)
    {
        if (_page.EnableWriting)
        {
            base.Write(value);
            _output.AppendText(value.ToString()); // When character data is written, append it to the text box.            
        }
        
    }

    public override Encoding Encoding
    {
        get { return System.Text.Encoding.UTF8; }
    }
}

