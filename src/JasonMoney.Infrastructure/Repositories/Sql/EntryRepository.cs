using JasonMoney.Infrastructure.Core;
using JasonMoney.Infrastructure.Models;
using JasonMoney.Domain.Entries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.Infrastructure.Repositories.Sql
{
    public class EntryRepository : IEntryRepository
    {
        protected IDbExecuter E { get; }

        public EntryRepository(IDbExecuter executer)
        {
            E = executer;
        }

        public async Task<Entry> Insert(Entry entry, CancellationToken cancellationToken = default)
        {
            var results = await E.QueryAsync<EntryTransactionDto>(DbConstants.ConnectionStringName, "entries.Entry_Insert", new
            {
                accountId = entry.AccountId,
                payeeId = entry.Payee?.Id,
                transferAccountId = entry.TransferAccountId,
                date = entry.Date,
                isCleared = entry.IsCleared,
                isActive = entry.IsActive,
                transactions = entry.Transactions.ToTableValuedParameter(),
            }, cancellationToken);
            return EntryTransactionDto.ToDomainModel(results)
                ?? throw new Exception("Database insert failed to return rows!");
        }

        public async Task<Entry?> UpdateDetails(Entry entry, CancellationToken cancellationToken = default)
        {
            var results = await E.QueryAsync<EntryTransactionDto>(DbConstants.ConnectionStringName, "entries.Entry_UpdateDetails", new
            {
                id = entry.Id,
                accountId = entry.AccountId,
                payeeId = entry.Payee?.Id,
                transferAccountId = entry.TransferAccountId,
                date = entry.Date,
                transactions = entry.Transactions.ToTableValuedParameter(),
            }, cancellationToken);
            return EntryTransactionDto.ToDomainModel(results);
        }

        public async Task<Entry?> UpdateStatus(Entry entry, DateTimeOffset statusDate, CancellationToken cancellationToken = default)
        {
            var results = await E.QueryAsync<EntryTransactionDto>(DbConstants.ConnectionStringName, "entries.Entry_UpdateStatus", new
            {
                id = entry.Id,
                date = statusDate,
                isCleared = entry.IsCleared,
                isActive = entry.IsActive,
            }, cancellationToken);
            return EntryTransactionDto.ToDomainModel(results);
        }

        public async Task<Entry?> GetById(long id, CancellationToken cancellationToken = default)
        {
            var results = await E.QueryAsync<EntryTransactionDto>(DbConstants.ConnectionStringName, "entries.EntryTransaction_GetByEntryId", new
            {
                entryId = id,
            }, cancellationToken);
            return EntryTransactionDto.ToDomainModel(results);
        }

        public async Task<IReadOnlyCollection<Entry>> GetPageByAccount(Guid accountId, int skip, int take, CancellationToken cancellationToken = default)
        {
            var results = await E.QueryAsync<EntryTransactionDto>(DbConstants.ConnectionStringName, "entries.EntryTransaction_GetPageByAccount", new
            {
                accountId,
                skip,
                take
            }, cancellationToken);
            return results.GroupBy(r => r.EntryId).Select(r => EntryTransactionDto.ToDomainModel(r)!).ToList();
        }
    }
}
