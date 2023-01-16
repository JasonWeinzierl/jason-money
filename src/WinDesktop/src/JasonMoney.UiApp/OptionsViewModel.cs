using CommunityToolkit.Mvvm.ComponentModel;
using JasonMoney.Api.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.UiApp;

public partial class OptionsViewModel : ObservableObject, IActivatable
{
    private readonly IHttpClientFactory _httpClientFactory;
    [ObservableProperty] private ObservableCollection<AccountResponse> accounts = new();

    public OptionsViewModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task ActivateAsync(CancellationToken cancellationToken = default)
    {
        var httpClient = _httpClientFactory.CreateClient("JasonMoney.Api");

        var accounts = await httpClient.GetFromJsonAsync<IEnumerable<AccountResponse>>("api/accounts", cancellationToken);
        Debug.Assert(accounts is not null);

        Accounts = new(accounts);
    }
}
