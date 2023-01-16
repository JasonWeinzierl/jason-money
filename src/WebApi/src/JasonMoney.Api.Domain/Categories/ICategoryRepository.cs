using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.Domain.Categories;

public interface ICategoryRepository
{
    Task<Category?> GetByUid(Guid uid, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Category>> GetAll(CancellationToken cancellationToken = default);
    Task<Category> Insert(Category request, CancellationToken cancellationToken = default);
    Task<Category?> Update(Category request, CancellationToken cancellationToken = default);
}
