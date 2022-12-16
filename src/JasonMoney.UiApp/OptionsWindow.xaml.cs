using System.Windows;

namespace JasonMoney.UiApp
{
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window, ICloseable
    {
        public OptionsWindow()
        {
            InitializeComponent();
            DataContext = App.Current.GetViewModel<OptionsViewModel>();
        }
    }
}
