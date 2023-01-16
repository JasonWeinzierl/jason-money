using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.Domain.Accounts;

public interface IAccountGroupRepository
{
    Task<IReadOnlyCollection<AccountGroup>> GetAll(CancellationToken cancellationToken = default);
    Task<AccountGroup?> GetByUid(Guid uid, CancellationToken cancellationToken = default);
    Task<AccountGroup> Insert(AccountGroup accountGroup, CancellationToken cancellationToken = default);
    Task<AccountGroup?> Update(AccountGroup accountGroup, CancellationToken cancellationToken = default);
}
