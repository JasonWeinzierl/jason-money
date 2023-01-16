using JasonMoney.Domain.Accounts;
using System;

namespace JasonMoney.Infrastructure.Models;

internal record AccountGroupDto(
    Guid Uid,
    int Id,
    string Name)
{
    public AccountGroup ToDomainModel()
        => new(Uid, Name);
}
