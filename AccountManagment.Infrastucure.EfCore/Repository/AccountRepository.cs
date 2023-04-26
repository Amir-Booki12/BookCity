

using _01_Framework.Application;
using _01_Framework.Domain.Infrastucure;
using AccountManagment.Application.Contracts.Accounts;
using AccountManagment.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;

namespace AccountManagment.Infrastucure.EfCore.Repository
{
    public class AccountRepository : Repository<long, Account>, IAccountRepository
    {
        private readonly AccountContext _context;

        public AccountRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public EditAccount GetDetails(long id)
        {
            return _context.Accounts.Select(x => new EditAccount
            {
                Id = x.Id,
                FullName = x.FullName,
                Mobile = x.Mobile,
                RoleId = x.RoleId,
                UserName = x.UserName,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            var result = _context.Accounts.Include(x => x.Role).Select(x => new AccountViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                UserName = x.UserName,
                Mobile = x.Mobile,
                RoleId = x.RoleId,
                RoleName = x.Role.Name,
                ProfilePhoto = x.ProfilePhoto,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(searchModel.FullName))
                result = result.Where(x => x.FullName.Contains(searchModel.FullName));

            if (!string.IsNullOrWhiteSpace(searchModel.UserName))
                result = result.Where(x => x.UserName.Contains(searchModel.UserName));

            if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
                result = result.Where(x => x.Mobile.Contains(searchModel.Mobile));

            if (searchModel.RoleId > 0)
                result = result.Where(x => x.RoleId == searchModel.RoleId);

            return result.OrderByDescending(x => x.Id).ToList();
        }
    }
}
