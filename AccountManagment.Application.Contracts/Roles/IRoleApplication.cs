

using _01_Framework.Application;

namespace AccountManagment.Application.Contracts.Roles
{
    public interface IRoleApplication
    {
        OperationResult Create(CreateRole command);
        OperationResult Edit(EditRole command);

        EditRole GetDetails(long id);
        List<RoleViewModel> List();
    }
}
