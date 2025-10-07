using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TestManyPage.ViewModels;

namespace TestManyPage;

public partial class Page2 : UserControl
{
    public Page2()
    {
        InitializeComponent();
        DataContext = new Page2ViewModel();
    }
}