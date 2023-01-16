using JasonMoney.Domain.Accounts;
using System;

namespace JasonMoney.Infrastructure.Models;

internal record AccountDto(
    Guid Uid,
    int Id,

    string Name,

    Guid? GroupUid,
    int? GroupId,
    string? GroupName,

    string? BankSwift,
    string? ExternalId,
    string? Description)
{
    public Account ToDomainModel()
    {
        AccountGroup? group = null;
        if (GroupUid.HasValue)
            group = new AccountGroup(GroupUid.Value, GroupName!);

        return new Account(Uid, Name, Description, BankSwift, ExternalId, group);
    }
}
