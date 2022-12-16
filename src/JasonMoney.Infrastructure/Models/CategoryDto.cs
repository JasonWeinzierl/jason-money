using JasonMoney.Domain.Categories;
using System;

namespace JasonMoney.Infrastructure.Models
{
    internal record CategoryDto(
        int Id,
        Guid AccountId,
        string Name,
        string? Subname)
    {
        public Category ToDomainModel()
            => new(Id, AccountId, Name, Subname);
    }
}
