

using _01_Framework.Domain;
using AccountManagment.Application.Contracts.Accounts;

namespace AccountManagment.Domain.AccountAgg
{
    public interface IAccountRepository : IRepository<long, Account>
    {
        EditAccount GetDetails(long id);
        List<AccountViewModel> Search(AccountSearchModel searchModel);
    }
}
