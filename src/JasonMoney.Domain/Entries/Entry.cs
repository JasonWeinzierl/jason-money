using JasonMoney.Domain.Categories;
using JasonMoney.Domain.Payees;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JasonMoney.Domain.Entries
{
    public record Entry(
        long Id,
        DateTimeOffset Date,
        Guid AccountId,
        Payee? Payee,
        Guid? TransferAccountId,
        DateTimeOffset StatusDate, // TODO: split status into a separate object?  into a list, like transaction? with another event table?
        bool IsCleared,
        bool IsActive,
        IReadOnlyCollection<EntryTransaction> Transactions)
    {
        /// <summary>
        /// Gets the entry's category, or null if the entry is split or uncategorized.
        /// </summary>
        public Category? Category => Transactions.Count == 1 ? Transactions.Single().Category : default;

        /// <summary>
        /// Gets the total sum of all transaction amounts.
        /// </summary>
        public decimal Flow => Transactions.Sum(t => t.Amount);

        /// <summary>
        /// Gets the entry's memo, or null if the entry is split.
        /// </summary>
        public string? Memo => Transactions.Count == 1 ? Transactions.Single().Memo : default;
    }
}
