using JasonMoney.Domain.Categories;
using JasonMoney.Domain.Entries;
using JasonMoney.Domain.Payees;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JasonMoney.Infrastructure.Models;

internal record EntryTransactionDto(
    Guid EntryUid,
    long EntryId,
    DateTimeOffset Date,
    Guid AccountUid,

    Guid? PayeeUid,
    long? PayeeId,
    string? PayeeName,

    Guid? TransferAccountUid,

    bool IsCleared,
    bool IsActive,

    Guid? CategoryUid,
    int? CategoryId,
    string? CategoryName,
    string? CategorySubname,

    long TransactionId,
    decimal Amount,
    string? Memo)
{
    public static Entry? ToDomainModel(IEnumerable<EntryTransactionDto> rows)
    {
        var entry = rows.FirstOrDefault();
        if (entry is null)
            return default;

        Payee? payee = null;
        if (entry.PayeeUid.HasValue)
            payee = new Payee(entry.PayeeUid.Value, entry.PayeeName!);

        return new Entry(entry.EntryUid,
            entry.Date,
            entry.AccountUid,
            payee,
            entry.TransferAccountUid,
            entry.IsCleared,
            entry.IsActive,
            rows.Select(r => r.ToDomainModel()).ToList());
    }

    public EntryTransaction ToDomainModel()
    {
        Category? category = null;
        if (CategoryUid.HasValue)
            category = new(CategoryUid.Value, CategoryName!, CategorySubname);

        return new(Amount, Memo, category);
    }
}
