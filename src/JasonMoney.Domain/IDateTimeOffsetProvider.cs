using System;

namespace JasonMoney.Domain;

public interface IDateTimeOffsetProvider
{
    DateTimeOffset Now();
}
