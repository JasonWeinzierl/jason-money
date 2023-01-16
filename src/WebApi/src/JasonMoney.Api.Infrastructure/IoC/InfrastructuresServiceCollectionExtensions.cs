using JasonMoney.Domain.Accounts;
using JasonMoney.Domain.Categories;
using JasonMoney.Domain.Entries;
using JasonMoney.Domain.Payees;
using JasonMoney.Infrastructure.Core;
using JasonMoney.Infrastructure.Repositories.Sql;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

namespace JasonMoney.Infrastructure.IoC;

public static class InfrastructuresServiceCollectionExtensions
{
    public static IServiceCollection AddInfra(this IServiceCollection services)
    {
        DbProviderFactories.RegisterFactory(DbConstants.SqlClientProviderName, SqlClientFactory.Instance);

        services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();
        services.AddSingleton<IDbExecuter, DapperExecuter>();

        services.AddSingleton<IEntryRepository, EntryRepository>();
        services.AddSingleton<IAccountRepository, AccountRepository>();
        services.AddSingleton<IPayeeRepository, PayeeRepository>();
        services.AddSingleton<ICategoryRepository, CategoryRepository>();
        services.AddSingleton<IAccountGroupRepository, AccountGroupRepository>();

        return services;
    }
}
