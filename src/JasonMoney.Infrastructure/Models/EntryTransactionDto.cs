using JasonMoney.Domain.Categories;
using JasonMoney.Domain.Entries;
using JasonMoney.Domain.Payees;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JasonMoney.Infrastructure.Models;

internal record EntryTransactionDto(
    long EntryId,
    DateTimeOffset Date,
    Guid AccountId,

    long? PayeeId,
    string? PayeeName,

    Guid? TransferAccountId,

    DateTimeOffset StatusDate,
    bool IsCleared,
    bool IsActive,

    int? CategoryId,
    Guid? CategoryAccountId,
    string? CategoryName,
    string? CategorySubname,

    long TransactionId,
    decimal Amount,
    string CurrencyCode,
    string? Memo)
{
    public static Entry? ToDomainModel(IEnumerable<EntryTransactionDto> rows)
    {
        var entry = rows.FirstOrDefault();
        if (entry is null)
            return default;

        Payee? payee = null;
        if (entry.PayeeId.HasValue)
            payee = new Payee(entry.PayeeId.Value, entry.AccountId, entry.PayeeName!);

        return new(entry.EntryId,
            entry.Date,
            entry.AccountId,
            payee,
            entry.TransferAccountId,
            entry.StatusDate,
            entry.IsCleared,
            entry.IsActive,
            rows.Select(r => r.ToDomainModel()).ToList());
    }

    public EntryTransaction ToDomainModel()
    {
        Category? category = null;
        if (CategoryId.HasValue)
            category = new(CategoryId.Value, CategoryAccountId!.Value, CategoryName!, CategorySubname);

        return new(TransactionId, EntryId, Amount, CurrencyCode, Memo, category);
    }
}
