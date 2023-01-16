using System;

namespace JasonMoney.Domain.Accounts;

public record Account(
    Guid Uid,
    string Name,
    string? Description,
    string? BankSwift,
    string? ExternalId,
    AccountGroup? Group);
