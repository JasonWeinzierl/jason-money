using JasonMoney.Infrastructure.Core;
using JasonMoney.Infrastructure.Models;
using JasonMoney.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.Infrastructure.Repositories.Sql;

public class CategoryRepository : ICategoryRepository
{
    protected IDbExecuter E { get; }

    public CategoryRepository(IDbExecuter executer)
    {
        E = executer;
    }

    public async Task<IReadOnlyCollection<Category>> GetByAccount(Guid id, CancellationToken cancellationToken = default)
    {
        var results = await E.QueryAsync<CategoryDto>(DbConstants.ConnectionStringName, "categories.Category_GetByAccount", new
        {
            id
        }, cancellationToken);
        return results.Select(r => r.ToDomainModel()).ToList();
    }

    public async Task<Category?> GetById(int id, CancellationToken cancellationToken = default)
    {
        var result = await E.QuerySingleOrDefaultAsync<CategoryDto>(DbConstants.ConnectionStringName, "categories.Category_GetById", new { id }, cancellationToken);
        return result?.ToDomainModel();
    }

    public async Task<Category> Insert(Category request, CancellationToken cancellationToken = default)
    {
        var result = await E.QuerySingleAsync<CategoryDto>(DbConstants.ConnectionStringName, "categories.Category_Insert", new
        {
            accountId = request.AccountId,
            name = request.Name,
            subname = request.Subname,
        }, cancellationToken);
        return result.ToDomainModel();
    }

    public async Task<Category?> Update(Category request, CancellationToken cancellationToken = default)
    {
        var result = await E.QuerySingleOrDefaultAsync<CategoryDto>(DbConstants.ConnectionStringName, "categories.Category_Update", new
        {
            id = request.Id,
            accountId = request.AccountId,
            name = request.Name,
            subname = request.Subname,
        }, cancellationToken);
        return result?.ToDomainModel();
    }
}
