using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TestManyPage.ViewModels;

namespace TestManyPage;

public partial class Page1 : UserControl
{
    public Page1()
    {
        InitializeComponent();
        DataContext = new Page1ViewModel();
    }
}