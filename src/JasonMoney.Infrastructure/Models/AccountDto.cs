using JasonMoney.Domain.Accounts;
using System;

namespace JasonMoney.Infrastructure.Models
{
    internal record AccountDto(
        Guid Id,

        string Name,

        int? GroupId,
        string? GroupName,

        string? BankSwift,
        string? ExternalId,
        string CurrencyCode,
        string? Description)
    {
        public Account ToDomainModel()
        {
            AccountGroup? group = null;
            if (GroupId.HasValue)
                group = new AccountGroup(GroupId.Value, GroupName!);

            return new Account(Id, Name, Description, CurrencyCode, BankSwift, ExternalId, group);
        }
    }
}
