using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Data.Common;

namespace JasonMoney.Infrastructure.Core;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;

    public SqlConnectionFactory(
        IConfiguration configuration,
        ILogger<SqlConnectionFactory> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public DbConnection CreateConnection(string connectionStringName)
    {
        if (string.IsNullOrEmpty(connectionStringName))
            throw new ArgumentNullException(nameof(connectionStringName));

        string connectionString = GetConnectionString(connectionStringName);

        return CreateSqlConnection(connectionString);
    }

    private string GetConnectionString(string connectionStringName)
    {
        string? connectionString = _configuration.GetConnectionString(connectionStringName);

        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException($"Connection string {connectionStringName} is not configured.");

        return connectionString;
    }

    private DbConnection CreateSqlConnection(string connectionString)
    {
        try
        {
            var connection = DbProviderFactories.GetFactory(DbConstants.SqlClientProviderName).CreateConnection()
                ?? throw new InvalidOperationException("Provider factory returned null connection.");

            connection.ConnectionString = connectionString;

            return connection;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create connection to database.  Is the provider factory '{ProviderInvariantName}' registered?", DbConstants.SqlClientProviderName);
            throw;
        }
    }
}
