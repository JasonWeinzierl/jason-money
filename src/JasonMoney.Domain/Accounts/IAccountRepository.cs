using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.Domain.Accounts;

public interface IAccountRepository
{
    Task Delete(Guid id, DateTimeOffset dateClosed, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Account>> GetAll(CancellationToken cancellationToken = default);
    Task<Account?> GetById(Guid id, CancellationToken cancellationToken = default);
    Task<Account> Insert(Account account, CancellationToken cancellationToken = default);
    Task<Account?> Update(Account account, CancellationToken cancellationToken = default);
}
