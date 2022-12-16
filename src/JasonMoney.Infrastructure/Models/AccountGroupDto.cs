using JasonMoney.Domain.Accounts;

namespace JasonMoney.Infrastructure.Models;

internal record AccountGroupDto(
    int Id,
    string Name)
{
    public AccountGroup ToDomainModel()
        => new(Id, Name);
}
