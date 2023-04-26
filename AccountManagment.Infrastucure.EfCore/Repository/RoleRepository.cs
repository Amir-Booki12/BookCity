using _01_Framework.Application;
using _01_Framework.Domain.Infrastucure;
using AccountManagment.Application.Contracts.Roles;
using AccountManagment.Domain.RoleAgg;

namespace AccountManagment.Infrastucure.EfCore.Repository
{
    public class RoleRepository : Repository<long, Role>, IRoleRepository
    {
        private readonly AccountContext _context;

        public RoleRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public EditRole GetDetails(long id)
        {
            return _context.Roles.Select(x => new EditRole
            {
                Id = x.Id,
                Name = x.Name,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<RoleViewModel> List()
        {
            return _context.Roles.Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi()

            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
