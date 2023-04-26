using _01_Framework.Domain;
using AccountManagment.Domain.AccountAgg;


namespace AccountManagment.Domain.RoleAgg
{
    public class Role : EntityBase
    {
        public string Name { get; private set; }
        public List<Account> Accounts { get; private set; }

        public Role(string name)
        {
            Name = name;
            Accounts = new List<Account>();
        }

        public void Edit(string name)
        {
            Name = name;
        }
    }
}
