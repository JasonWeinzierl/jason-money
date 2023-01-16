using JasonMoney.Infrastructure.Core;
using JasonMoney.Infrastructure.Models;
using JasonMoney.Domain.Payees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.Infrastructure.Repositories.Sql;

public class PayeeRepository : IPayeeRepository
{
    private readonly IDbExecuter _e;

    public PayeeRepository(IDbExecuter executer)
    {
        _e = executer;
    }

    public async Task<IReadOnlyCollection<Payee>> GetAll(CancellationToken cancellationToken = default)
    {
        var results = await _e.QueryAsync<PayeeDto>(DbConstants.ConnectionStringName, "payees.Payee_GetByPayerAccount", cancellationToken: cancellationToken);
        return results.Select(r => r.ToDomainModel()).ToList();
    }

    public async Task<Payee?> GetByUid(Guid uid, CancellationToken cancellationToken = default)
    {
        var result = await _e.QuerySingleOrDefaultAsync<PayeeDto>(DbConstants.ConnectionStringName, "payees.Payee_GetByUid", new { payeeId = uid }, cancellationToken);
        return result?.ToDomainModel();
    }

    public async Task<Payee> Insert(Payee payee, CancellationToken cancellationToken = default)
    {
        var result = await _e.QuerySingleAsync<PayeeDto>(DbConstants.ConnectionStringName, "payees.Payee_Insert", new
        {
            payeeUid = payee.Uid,
            name = payee.Name,
        }, cancellationToken);
        return result.ToDomainModel();
    }

    public async Task<Payee?> Update(Payee payee, CancellationToken cancellationToken = default)
    {
        var result = await _e.QuerySingleOrDefaultAsync<PayeeDto>(DbConstants.ConnectionStringName, "payees.Payee_Update", new
        {
            payeeUid = payee.Uid,
            name = payee.Name,
        }, cancellationToken);
        return result?.ToDomainModel();
    }
}
