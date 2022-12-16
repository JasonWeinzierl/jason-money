using JasonMoney.Infrastructure.Core;
using JasonMoney.Infrastructure.Models;
using JasonMoney.Domain.Accounts;
using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.Infrastructure.Repositories.Sql
{
    public class AccountGroupRepository : IAccountGroupRepository
    {
        protected IDbExecuter E { get; }

        public AccountGroupRepository(IDbExecuter executer)
        {
            E = executer;
        }

        public async Task<AccountGroup?> GetById(int id, CancellationToken cancellationToken = default)
        {
            var result = await E.QuerySingleOrDefaultAsync<AccountGroupDto>(DbConstants.ConnectionStringName, "accounts.AccountGroup_GetById", new { id }, cancellationToken);
            return result?.ToDomainModel();
        }
    }
}
