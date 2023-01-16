using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Reflection;

namespace JasonMoney.UiApp;

public partial class AboutViewModel : ObservableObject
{
    [ObservableProperty] private string name = nameof(JasonMoney);
    [ObservableProperty] private string? version;
    [ObservableProperty] private string? copyright;
    [ObservableProperty] private string? buildConfiguration;

    public AboutViewModel()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var assemblyName = assembly.GetName();
        var fileInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
        Name = fileInfo.FileDescription ?? assemblyName.Name ?? nameof(JasonMoney);
        Version = $"Version {fileInfo.ProductVersion ?? assemblyName.Version?.ToString() ?? "unversioned"}";
        Copyright = fileInfo.LegalCopyright;
        BuildConfiguration = assembly.GetCustomAttribute<AssemblyConfigurationAttribute>()?.Configuration;
    }

    [RelayCommand]
    private void Close(ICloseable? window)
    {
        if (window is not null)
            window.DialogResult = true;
    }
}
