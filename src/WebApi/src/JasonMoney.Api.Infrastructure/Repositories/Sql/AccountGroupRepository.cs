using JasonMoney.Infrastructure.Core;
using JasonMoney.Infrastructure.Models;
using JasonMoney.Domain.Accounts;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;

namespace JasonMoney.Infrastructure.Repositories.Sql;

public class AccountGroupRepository : IAccountGroupRepository
{
    private readonly IDbExecuter _e;

    public AccountGroupRepository(IDbExecuter dbExecuter)
    {
        _e = dbExecuter;
    }

    public async Task<IReadOnlyCollection<AccountGroup>> GetAll(CancellationToken cancellationToken = default)
    {
        var results = await _e.QueryAsync<AccountGroupDto>(DbConstants.ConnectionStringName, "accounts.AccountGroup_GetAll", cancellationToken: cancellationToken);
        return results.Select(r => r.ToDomainModel()).ToList();
    }

    public async Task<AccountGroup?> GetByUid(Guid uid, CancellationToken cancellationToken = default)
    {
        var result = await _e.QuerySingleOrDefaultAsync<AccountGroupDto>(DbConstants.ConnectionStringName, "accounts.AccountGroup_GetByUid", new { groupUid = uid }, cancellationToken);
        return result?.ToDomainModel();
    }

    public async Task<AccountGroup> Insert(AccountGroup accountGroup, CancellationToken cancellationToken = default)
    {
        var result = await _e.QuerySingleAsync<AccountGroupDto>(DbConstants.ConnectionStringName, "accounts.AccountGroup_Insert", new
        {
            groupUid = accountGroup.Uid,
            name = accountGroup.Name,
        }, cancellationToken);
        return result.ToDomainModel();
    }

    public async Task<AccountGroup?> Update(AccountGroup accountGroup, CancellationToken cancellationToken = default)
    {
        var result = await _e.QuerySingleOrDefaultAsync<AccountGroupDto>(DbConstants.ConnectionStringName, "accounts.AccountGroup_Update", new
        {
            groupUid = accountGroup.Uid,
            name = accountGroup.Name,
        }, cancellationToken);
        return result?.ToDomainModel();
    }
}
