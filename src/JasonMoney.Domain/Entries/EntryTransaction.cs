using JasonMoney.Domain.Categories;

namespace JasonMoney.Domain.Entries;

public record EntryTransaction(
    decimal Amount,
    string? Memo,
    Category? Category);
