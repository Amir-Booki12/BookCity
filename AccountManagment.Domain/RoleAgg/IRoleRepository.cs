

using _01_Framework.Domain;
using AccountManagment.Application.Contracts.Roles;

namespace AccountManagment.Domain.RoleAgg
{
    public interface IRoleRepository : IRepository<long, Role>
    {
        EditRole GetDetails(long id);
        List<RoleViewModel> List();
    }
}
