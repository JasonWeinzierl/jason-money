using System;

namespace JasonMoney.Domain.Accounts;

public record Account(
    Guid Id,
    string Name,
    string? Description,
    string CurrencyCode,
    string? BankSwift,
    string? ExternalId,
    AccountGroup? Group)
{
    public static Account New(string Name, string? Description, string CurrencyCode, string? BankSwift, string? ExternalId, AccountGroup? Group)
        => new(Guid.NewGuid(), Name, Description, CurrencyCode, BankSwift, ExternalId, Group);
}
