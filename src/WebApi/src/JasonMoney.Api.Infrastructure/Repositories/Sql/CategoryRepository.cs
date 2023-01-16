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
    private readonly IDbExecuter _e;

    public CategoryRepository(IDbExecuter executer)
    {
        _e = executer;
    }

    public async Task<IReadOnlyCollection<Category>> GetAll(CancellationToken cancellationToken = default)
    {
        var results = await _e.QueryAsync<CategoryDto>(DbConstants.ConnectionStringName, "categories.Category_GetAll", cancellationToken: cancellationToken);
        return results.Select(r => r.ToDomainModel()).ToList();
    }

    public async Task<Category?> GetByUid(Guid uid, CancellationToken cancellationToken = default)
    {
        var result = await _e.QuerySingleOrDefaultAsync<CategoryDto>(DbConstants.ConnectionStringName, "categories.Category_GetById", new
        {
            categoryUid = uid,
        }, cancellationToken);
        return result?.ToDomainModel();
    }

    public async Task<Category> Insert(Category request, CancellationToken cancellationToken = default)
    {
        var result = await _e.QuerySingleAsync<CategoryDto>(DbConstants.ConnectionStringName, "categories.Category_Insert", new
        {
            categoryUid = request.Uid,
            name = request.Name,
            subname = request.Subname,
        }, cancellationToken);
        return result.ToDomainModel();
    }

    public async Task<Category?> Update(Category request, CancellationToken cancellationToken = default)
    {
        var result = await _e.QuerySingleOrDefaultAsync<CategoryDto>(DbConstants.ConnectionStringName, "categories.Category_Update", new
        {
            categoryUid = request.Uid,
            name = request.Name,
            subname = request.Subname,
        }, cancellationToken);
        return result?.ToDomainModel();
    }
}
