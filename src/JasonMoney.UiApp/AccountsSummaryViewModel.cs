using CommunityToolkit.Mvvm.ComponentModel;
using JasonMoney.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.UiApp
{
    public class AccountsSummaryViewModel : ObservableObject, IActivatable
    {
        private readonly IAccountRepository _accountRepo;

        public AccountsSummaryViewModel(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public Task ActivateAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
