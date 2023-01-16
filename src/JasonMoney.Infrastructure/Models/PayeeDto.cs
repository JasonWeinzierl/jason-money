using JasonMoney.Domain.Payees;
using System;

namespace JasonMoney.Infrastructure.Models;

internal record PayeeDto(
    Guid Uid,
    long Id,
    string Name)
{
    public Payee ToDomainModel()
        => new(Uid, Name);
}
