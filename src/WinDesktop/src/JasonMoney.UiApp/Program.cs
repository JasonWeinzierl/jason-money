using Dapplo.Microsoft.Extensions.Hosting.Wpf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace JasonMoney.UiApp;

public static class Program
{
    public static async Task Main(string[] args)
    {
        await CreateHostBuilder(args).RunConsoleAsync();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<INavigationService, NavigationService>();
                services.AddTransient<AboutWindow>();
                services.AddTransient<OptionsWindow>();

                services.AddSingleton<MainViewModel>();
                services.AddTransient<AboutViewModel>();
                services.AddTransient<AccountsSummaryViewModel>();
                services.AddTransient<OptionsViewModel>();

                services.AddHttpClient("JasonMoney.Api")
                    .ConfigureHttpClient(httpClient => httpClient.BaseAddress = new Uri(context.Configuration.GetConnectionString("JasonMoney.Api")));
            })
            .ConfigureWpf(wpfBuilder =>
            {
                wpfBuilder.UseApplication<App>();
                wpfBuilder.UseWindow<MainWindow>(); // Must implement IWpfShell.
            })
            .UseWpfLifetime(ShutdownMode.OnMainWindowClose);
}
