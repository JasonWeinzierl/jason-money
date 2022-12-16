using JasonMoney.Domain.Payees;
using System;

namespace JasonMoney.Infrastructure.Models;

internal record PayeeDto(
    long Id,
    Guid PayerAccountId,
    string Name)
{
    public Payee ToDomainModel()
        => new(Id, PayerAccountId, Name);
}
