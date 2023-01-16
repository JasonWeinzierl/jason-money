using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.Domain.Payees;

public interface IPayeeRepository
{
    Task<IReadOnlyCollection<Payee>> GetAll(CancellationToken cancellationToken = default);
    Task<Payee?> GetByUid(Guid uid, CancellationToken cancellationToken = default);
    Task<Payee> Insert(Payee payee, CancellationToken cancellationToken = default);
    Task<Payee?> Update(Payee payee, CancellationToken cancellationToken = default);
}
