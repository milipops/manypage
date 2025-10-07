using Avalonia.Controls;
using ReactiveUI;

namespace TestManyPage.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static MainWindowViewModel Instance;
        public MainWindowViewModel() 
        { 
            Instance = this;
        }

        UserControl _uc = new Page1();
        public UserControl Uc
        {
            get => _uc;
            set => this.RaiseAndSetIfChanged(ref _uc, value);
        }
        
    }
}
