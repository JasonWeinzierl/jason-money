using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.Domain.Payees;

public interface IPayeeRepository
{
    Task<Payee?> GetById(long id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Payee>> GetByPayerAccount(Guid accountId, CancellationToken cancellationToken = default);
    Task<Payee> Insert(Payee payee, CancellationToken cancellationToken = default);
    Task<Payee?> Update(Payee payee, CancellationToken cancellationToken = default);
}
