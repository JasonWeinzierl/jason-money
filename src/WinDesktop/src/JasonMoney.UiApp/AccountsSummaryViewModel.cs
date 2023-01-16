using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.UiApp;

public class AccountsSummaryViewModel : ObservableObject, IActivatable
{
    public AccountsSummaryViewModel()
    {
    }

    public Task ActivateAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
