using CommunityToolkit.Mvvm.ComponentModel;
using JasonMoney.Domain.Accounts;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.UiApp;

public partial class OptionsViewModel : ObservableObject, IActivatable
{
    private readonly IAccountRepository _accountRepo;
    [ObservableProperty] private ObservableCollection<Account> accounts = new();

    public OptionsViewModel(IAccountRepository accountRepo)
    {
        _accountRepo = accountRepo;
    }

    public async Task ActivateAsync(CancellationToken cancellationToken = default)
    {
        Accounts = new(await _accountRepo.GetAll(cancellationToken));
    }
}
