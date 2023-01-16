using JasonMoney.Infrastructure.Core;
using JasonMoney.Infrastructure.Models;
using JasonMoney.Domain.Entries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.Infrastructure.Repositories.Sql;

public class EntryRepository : IEntryRepository
{
    private readonly IDbExecuter _e;

    public EntryRepository(IDbExecuter executer)
    {
        _e = executer;
    }

    public async Task<Entry> Insert(Entry entry, CancellationToken cancellationToken = default)
    {
        var results = await _e.QueryAsync<EntryTransactionDto>(DbConstants.ConnectionStringName, "entries.Entry_Insert", new
        {
            entryUid = entry.Uid,
            accountUid = entry.AccountUid,
            payeeUid = entry.Payee?.Uid,
            transferAccountUid = entry.TransferAccountUid,
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
        var results = await _e.QueryAsync<EntryTransactionDto>(DbConstants.ConnectionStringName, "entries.Entry_UpdateDetails", new
        {
            entryUid = entry.Uid,
            accountUid = entry.AccountUid,
            payeeUid = entry.Payee?.Uid,
            transferAccountUid = entry.TransferAccountUid,
            date = entry.Date,
            transactions = entry.Transactions.ToTableValuedParameter(),
        }, cancellationToken);
        return EntryTransactionDto.ToDomainModel(results);
    }

    public async Task<Entry?> UpdateStatus(Entry entry, DateTimeOffset statusDate, CancellationToken cancellationToken = default)
    {
        var results = await _e.QueryAsync<EntryTransactionDto>(DbConstants.ConnectionStringName, "entries.Entry_UpdateStatus", new
        {
            entryUid = entry.Uid,
            isCleared = entry.IsCleared,
            isActive = entry.IsActive,
        }, cancellationToken);
        return EntryTransactionDto.ToDomainModel(results);
    }

    public async Task<Entry?> GetByUid(Guid uid, CancellationToken cancellationToken = default)
    {
        var results = await _e.QueryAsync<EntryTransactionDto>(DbConstants.ConnectionStringName, "entries.EntryTransaction_GetByEntryUid", new
        {
            entryUid = uid,
        }, cancellationToken);
        return EntryTransactionDto.ToDomainModel(results);
    }

    public async Task<IReadOnlyCollection<Entry>> GetPageByAccount(Guid accountUid, int skip, int take, CancellationToken cancellationToken = default)
    {
        var results = await _e.QueryAsync<EntryTransactionDto>(DbConstants.ConnectionStringName, "entries.EntryTransaction_GetPageByAccount", new
        {
            accountUid,
            skip,
            take,
        }, cancellationToken);
        return results.GroupBy(r => r.EntryId).Select(r => EntryTransactionDto.ToDomainModel(r)!).ToList();
    }
}
