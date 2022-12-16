using System.Windows;
using System;

namespace JasonMoney.UiApp;

/// <summary>
/// A window that supports closing.
/// </summary>
public interface ICloseable
{
    /// <summary>
    /// Manually closes a <see cref="Window"/>.
    /// </summary>
    void Close();

    /// <summary>
    /// Gets or sets the dialog result value,
    /// which is the value returned from <see cref="Window.ShowDialog"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// If the window was opened using <see cref="Window.ShowDialog"/>,
    /// the window closes as soon as the <see cref="DialogResult"/> property is set to a value.
    /// </para>
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// <see cref="DialogResult"/> is set on a window that is opened by calling <see cref="Window.Show"/>.
    /// </exception>
    bool? DialogResult { get; set; }
}
