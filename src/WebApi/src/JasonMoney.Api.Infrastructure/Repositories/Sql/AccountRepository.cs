using JasonMoney.Infrastructure.Core;
using JasonMoney.Infrastructure.Models;
using JasonMoney.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.Infrastructure.Repositories.Sql;

public class AccountRepository : IAccountRepository
{
    private readonly IDbExecuter _e;

    public AccountRepository(IDbExecuter executer)
    {
        _e = executer;
    }


    public async Task Delete(Guid uid, DateTimeOffset dateClosed, CancellationToken cancellationToken = default)
        => await _e.ExecuteNonQueryAsync(DbConstants.ConnectionStringName, "accounts.Account_Delete", new { accountUid = uid, dateClosed }, cancellationToken);
    public async Task<IReadOnlyCollection<Account>> GetAll(CancellationToken cancellationToken = default)
    {
        var results = await _e.QueryAsync<AccountDto>(DbConstants.ConnectionStringName, "accounts.Account_GetAll", cancellationToken: cancellationToken);
        return results.Select(r => r.ToDomainModel()).ToList();
    }

    public async Task<Account?> GetByUid(Guid uid, CancellationToken cancellationToken = default)
    {
        var result = await _e.QuerySingleOrDefaultAsync<AccountDto>(DbConstants.ConnectionStringName, "accounts.Account_GetByUid", new { accountUid = uid }, cancellationToken);
        return result?.ToDomainModel();
    }

    public async Task<Account> Insert(Account account, CancellationToken cancellationToken = default)
    {
        var result = await _e.QuerySingleAsync<AccountDto>(DbConstants.ConnectionStringName, "accounts.Account_Insert", new
        {
            accountUid = account.Uid,

            name = account.Name,
            groupUid = account.Group?.Uid,
            bankSwift = account.BankSwift,
            externalId = account.ExternalId,
            description = account.Description,
        }, cancellationToken);
        return result.ToDomainModel();
    }

    public async Task<Account?> Update(Account account, CancellationToken cancellationToken = default)
    {
        var result = await _e.QuerySingleOrDefaultAsync<AccountDto>(DbConstants.ConnectionStringName, "accounts.Account_Update", new
        {
            accountUid = account.Uid,

            name = account.Name,
            groupUid = account.Group?.Uid,
            bankSwift = account.BankSwift,
            externalId = account.ExternalId,
            description = account.Description,
        }, cancellationToken);
        return result?.ToDomainModel();
    }
}
