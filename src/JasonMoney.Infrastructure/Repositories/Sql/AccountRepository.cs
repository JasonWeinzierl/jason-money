using JasonMoney.Infrastructure.Core;
using JasonMoney.Infrastructure.Models;
using JasonMoney.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.Infrastructure.Repositories.Sql
{
    public class AccountRepository : IAccountRepository
    {
        protected IDbExecuter E { get; }

        public AccountRepository(IDbExecuter executer)
        {
            E = executer;
        }

        public async Task<Account?> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await E.QuerySingleOrDefaultAsync<AccountDto>(DbConstants.ConnectionStringName, "accounts.Account_GetById", new { id }, cancellationToken);
            return result?.ToDomainModel();
        }

        public async Task<IReadOnlyCollection<Account>> GetAll(CancellationToken cancellationToken = default)
        {
            var results = await E.QueryAsync<AccountDto>(DbConstants.ConnectionStringName, "accounts.Account_GetAll", cancellationToken: cancellationToken);
            return results.Select(r => r.ToDomainModel()).ToList();
        }

        public async Task<Account> Insert(Account account, CancellationToken cancellationToken = default)
        {
            var result = await E.QuerySingleAsync<AccountDto>(DbConstants.ConnectionStringName, "accounts.Account_Insert", new
            {
                id = account.Id,
                name = account.Name,
                groupId = account.Group?.Id,
                bankSwift = account.BankSwift,
                externalId = account.ExternalId,
                currencyCode = account.CurrencyCode,
                description = account.Description,
            }, cancellationToken);
            return result.ToDomainModel();
        }

        public async Task<Account?> Update(Account account, CancellationToken cancellationToken = default)
        {
            var result = await E.QuerySingleOrDefaultAsync<AccountDto>(DbConstants.ConnectionStringName, "accounts.Account_Update", new
            {
                id = account.Id,
                name = account.Name,
                groupId = account.Group?.Id,
                bankSwift = account.BankSwift,
                externalId = account.ExternalId,
                currencyCode = account.CurrencyCode,
                description = account.Description,
            }, cancellationToken);
            return result?.ToDomainModel();
        }

        public async Task Delete(Guid id, DateTimeOffset dateClosed, CancellationToken cancellationToken = default)
            => await E.ExecuteNonQueryAsync(DbConstants.ConnectionStringName, "accounts.Account_Delete", new { id, dateClosed }, cancellationToken);
    }
}
