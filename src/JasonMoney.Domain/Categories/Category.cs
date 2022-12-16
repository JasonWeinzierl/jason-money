using System;

namespace JasonMoney.Domain.Categories
{
    public record Category(
        int Id,
        Guid AccountId,
        string Name,
        string? Subname);
}
