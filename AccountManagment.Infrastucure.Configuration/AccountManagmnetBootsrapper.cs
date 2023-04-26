

using AccountManagment.Application;
using AccountManagment.Application.Contracts.Accounts;
using AccountManagment.Application.Contracts.Roles;
using AccountManagment.Domain.AccountAgg;
using AccountManagment.Domain.RoleAgg;
using AccountManagment.Infrastucure.EfCore;
using AccountManagment.Infrastucure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagment.Infrastucure.Configuration
{
    public class AccountManagmnetBootsrapper
    {
        
        public static void Configure(IServiceCollection services,string connectionString)
        {
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountApplication, AccountApplication>();


            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IRoleApplication, RoleApplication>();

            services.AddDbContext<AccountContext>(x=>x.UseSqlServer(connectionString));

        }
    }
}
