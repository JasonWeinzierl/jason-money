using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.Domain.Categories;

public interface ICategoryRepository
{
    Task<Category?> GetById(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Category>> GetByAccount(Guid accountId, CancellationToken cancellationToken = default);
    Task<Category> Insert(Category request, CancellationToken cancellationToken = default);
    Task<Category?> Update(Category request, CancellationToken cancellationToken = default);
}
