using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace JasonMoney.UiApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IServiceProvider _services;

    public App(IServiceProvider services)
    {
        InitializeComponent();
        _services = services;
    }

    public static new App Current => (App)Application.Current;

    public T GetViewModel<T>() where T : notnull, ObservableObject
        => _services.GetRequiredService<T>();
}
