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
    protected IDbExecuter E { get; }

    public PayeeRepository(IDbExecuter executer)
    {
        E = executer;
    }

    public async Task<Payee?> GetById(long id, CancellationToken cancellationToken = default)
    {
        var result = await E.QuerySingleOrDefaultAsync<PayeeDto>(DbConstants.ConnectionStringName, "payees.Payee_GetById", new { id }, cancellationToken);
        return result?.ToDomainModel();
    }

    public async Task<IReadOnlyCollection<Payee>> GetByPayerAccount(Guid accountId, CancellationToken cancellationToken = default)
    {
        var results = await E.QueryAsync<PayeeDto>(DbConstants.ConnectionStringName, "payees.Payee_GetByPayerAccount", new { accountId }, cancellationToken);
        return results.Select(r => r.ToDomainModel()).ToList();
    }

    public async Task<Payee> Insert(Payee payee, CancellationToken cancellationToken = default)
    {
        var result = await E.QuerySingleAsync<PayeeDto>(DbConstants.ConnectionStringName, "payees.Payee_Insert", new
        {
            payerAccountId = payee.PayerAccountId,
            name = payee.Name
        }, cancellationToken);
        return result.ToDomainModel();
    }

    public async Task<Payee?> Update(Payee payee, CancellationToken cancellationToken = default)
    {
        var result = await E.QuerySingleOrDefaultAsync<PayeeDto>(DbConstants.ConnectionStringName, "payees.Payee_Update", new
        {
            id = payee.Id,
            payerAccountId = payee.PayerAccountId,
            name = payee.Name
        }, cancellationToken);
        return result?.ToDomainModel();
    }
}
