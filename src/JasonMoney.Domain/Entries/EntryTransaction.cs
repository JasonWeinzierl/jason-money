using JasonMoney.Domain.Categories;

namespace JasonMoney.Domain.Entries;

public record EntryTransaction(
    long Id,
    long EntryId,
    decimal Amount,
    string CurrencyCode,
    string? Memo,
    Category? Category);
