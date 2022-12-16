using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace JasonMoney.UiApp
{
    public interface INavigationService
    {
        void ShowAboutPopup();
        Task ShowOptionsPopup(CancellationToken cancellationToken = default);
    }

    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _services;

        public NavigationService(IServiceProvider services)
        {
            _services = services;
        }

        public async Task ShowOptionsPopup(CancellationToken cancellationToken = default)
        {
            var window = await ActivateWindow<OptionsWindow>(cancellationToken);
            window.Owner = Application.Current.MainWindow; // Enable window flicker when focus lost.  Note this doesn't work when debugging in VS (https://github.com/dotnet/wpf/issues/2966).
            window.ShowInTaskbar = false;
            window.ShowDialog();
        }

        public void ShowAboutPopup()
        {
            var window = GetWindow<AboutWindow>();
            window.Owner = Application.Current.MainWindow;
            window.ShowInTaskbar = false;
            window.ShowDialog();
        }

        private async Task<TWindow> ActivateWindow<TWindow>(CancellationToken cancellationToken)
            where TWindow : Window
        {
            var window = GetWindow<TWindow>();

            if (window.DataContext is IActivatable viewModel)
                await viewModel.ActivateAsync(cancellationToken);

            return window;
        }

        private T GetWindow<T>() where T : Window
            => _services.GetRequiredService<T>();
    }
}
