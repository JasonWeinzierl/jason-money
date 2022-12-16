using System;

namespace JasonMoney.Domain.Payees
{
    public record Payee(
        long Id,
        Guid PayerAccountId,
        string Name);
}
