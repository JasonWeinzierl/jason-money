using JasonMoney.Domain.Categories;
using System;

namespace JasonMoney.Infrastructure.Models;

internal record CategoryDto(
    Guid Uid,
    int Id,
    string Name,
    string? Subname)
{
    public Category ToDomainModel()
        => new(Uid, Name, Subname);
}
