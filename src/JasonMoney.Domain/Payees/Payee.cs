using System;

namespace JasonMoney.Domain.Payees;

public record Payee(
    Guid Uid,
    string Name);
