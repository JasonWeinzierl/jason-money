using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.UiApp;

public partial class MainViewModel : ObservableObject
{
    private readonly IHostApplicationLifetime _lifetime;
    private readonly INavigationService _navService;

    public MainViewModel(
        IHostApplicationLifetime lifetime,
        INavigationService navService)
    {
        _lifetime = lifetime;
        _navService = navService;
    }

    [RelayCommand]
    private void ShowAbout()
    {
        _navService.ShowAboutPopup();
    }

    [RelayCommand]
    private async Task ShowOptions(CancellationToken cancellationToken)
    {
        await _navService.ShowOptionsPopup(cancellationToken);
    }

    [RelayCommand]
    private void CloseWindow()
    {
        _lifetime.StopApplication();
    }
}
