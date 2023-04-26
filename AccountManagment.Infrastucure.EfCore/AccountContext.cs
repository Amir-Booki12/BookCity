

using AccountManagment.Domain.AccountAgg;
using AccountManagment.Domain.RoleAgg;
using AccountManagment.Infrastucure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AccountManagment.Infrastucure.EfCore
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Role> Roles { get; set; }

        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assemble = typeof(AccountMapping).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(assemble);

            base.OnModelCreating(modelBuilder);
        }
    }
}
