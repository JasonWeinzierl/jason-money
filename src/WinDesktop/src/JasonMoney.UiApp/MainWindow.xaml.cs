using Dapplo.Microsoft.Extensions.Hosting.Wpf;
using System.Windows;

namespace JasonMoney.UiApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
    , IWpfShell // Necessary for Dapplo's worker to open this on startup.
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = App.Current.GetViewModel<MainViewModel>();
    }
}
