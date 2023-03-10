using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.Domain.Entries;

public interface IEntryRepository
{
    Task<Entry?> GetByUid(Guid uid, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Entry>> GetPageByAccount(Guid accountUid, int skip, int take, CancellationToken cancellationToken = default);
    Task<Entry> Insert(Entry entry, CancellationToken cancellationToken = default);
    Task<Entry?> UpdateDetails(Entry entry, CancellationToken cancellationToken = default);
    Task<Entry?> UpdateStatus(Entry entry, DateTimeOffset statusDate, CancellationToken cancellationToken = default);
}
