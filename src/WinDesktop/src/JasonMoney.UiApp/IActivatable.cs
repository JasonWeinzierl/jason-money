using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.UiApp;

/// <summary>
/// A view model that supports activation.
/// </summary>
public interface IActivatable
{
    /// <summary>
    /// Activates the view model.
    /// </summary>
    Task ActivateAsync(CancellationToken cancellationToken = default);
}
