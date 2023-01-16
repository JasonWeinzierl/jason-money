using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.Infrastructure.Core;

public interface IDbExecuter
{
    Task<int> ExecuteNonQueryAsync(string connectionStringName, string commandText, object? parameters = null, CancellationToken cancellationToken = default);

    Task<IEnumerable<T>> QueryAsync<T>(string connectionStringName, string commandText, object? parameters = null, CancellationToken cancellationToken = default);

    Task<T> QuerySingleAsync<T>(string connectionStringName, string commandText, object? parameters = null, CancellationToken cancellationToken = default);

    Task<T?> QuerySingleOrDefaultAsync<T>(string connectionStringName, string commandText, object? parameters = null, CancellationToken cancellationToken = default);
}
