using Avalonia.Controls;
using Avalonia.Controls.Documents;

namespace HelloWorldCross.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        // var fallbackFont = Avalonia.Media.FontManager.Current.DefaultFontFamily;

        // myCharacters.FontFamily = fallbackFont;

        // TextElement.SetFontFamily(myCharacters, fallbackFont);
    }
}
