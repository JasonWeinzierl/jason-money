using System.Threading;
using System.Threading.Tasks;

namespace JasonMoney.Domain.Accounts
{
    public interface IAccountGroupRepository
    {
        Task<AccountGroup?> GetById(int id, CancellationToken cancellationToken = default);
    }
}
