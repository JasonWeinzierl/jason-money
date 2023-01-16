using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.Infrastructure.Core;

public class DapperExecuter : IDbExecuter
{
    private readonly ISqlConnectionFactory _factory;

    public DapperExecuter(ISqlConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<int> ExecuteNonQueryAsync(string connectionStringName, string commandText, object? parameters = null, CancellationToken cancellationToken = default)
    {
        using var connection = await Open(connectionStringName, cancellationToken);

        return await connection.ExecuteAsync(new CommandDefinition(
            commandText,
            parameters,
            commandType: CommandType.StoredProcedure,
            cancellationToken: cancellationToken));
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(string connectionStringName, string commandText, object? parameters = null, CancellationToken cancellationToken = default)
    {
        using var connection = await Open(connectionStringName, cancellationToken);

        return await connection.QueryAsync<T>(new CommandDefinition(
            commandText,
            parameters,
            commandType: CommandType.StoredProcedure,
            cancellationToken: cancellationToken));
    }

    public async Task<T> QuerySingleAsync<T>(string connectionStringName, string commandText, object? parameters = null, CancellationToken cancellationToken = default)
    {
        using var connection = await Open(connectionStringName, cancellationToken);

        return await connection.QuerySingleAsync<T>(new CommandDefinition(
            commandText,
            parameters,
            commandType: CommandType.StoredProcedure,
            cancellationToken: cancellationToken));
    }

    public async Task<T?> QuerySingleOrDefaultAsync<T>(string connectionStringName, string commandText, object? parameters = null, CancellationToken cancellationToken = default)
    {
        using var connection = await Open(connectionStringName, cancellationToken);

        return await connection.QuerySingleOrDefaultAsync<T>(new CommandDefinition(
            commandText,
            parameters,
            commandType: CommandType.StoredProcedure,
            cancellationToken: cancellationToken));
    }

    private async Task<DbConnection> Open(string connectionStringName, CancellationToken cancellationToken)
    {
        var connection = _factory.CreateConnection(connectionStringName);
        await connection.OpenAsync(cancellationToken);
        return connection;
    }
}
