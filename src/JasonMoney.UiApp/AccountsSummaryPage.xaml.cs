using System.Windows.Controls;

namespace JasonMoney.UiApp;

/// <summary>
/// Interaction logic for AccountsSummaryPage.xaml
/// </summary>
public partial class AccountsSummaryPage : Page
{
    public AccountsSummaryPage()
    {
        InitializeComponent();
        DataContext = App.Current.GetViewModel<AccountsSummaryViewModel>();
    }
}
