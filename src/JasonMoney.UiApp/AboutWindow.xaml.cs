using System.Windows;

namespace JasonMoney.UiApp
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window, ICloseable
    {
        public AboutWindow()
        {
            InitializeComponent();
            DataContext = App.Current.GetViewModel<AboutViewModel>();
        }
    }
}
