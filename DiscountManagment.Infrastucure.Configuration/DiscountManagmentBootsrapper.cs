using DiscountManagment.Application.CollegueDiscount;
using DiscountManagment.Application.Contract.CollegueDiscount;
using DiscountManagment.Application.Contract.CustomerDiscount;
using DiscountManagment.Application.CustomerDiscount;
using DiscountManagment.Domain.CollegueDiscount;
using DiscountManagment.Domain.CustomerDiscount;
using DiscountManagment.Infrastucure.EfCore;
using DiscountManagment.Infrastucure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace DiscountManagment.Infrastucure.Configuration
{
    public class DiscountManagmentBootsrapper
    {

        public static void Configure(IServiceCollection services , string connectionString)
        {
            services.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();
            services.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();

            services.AddTransient<ICollegueDiscountRepository, CollegueDiscountRepository>();
            services.AddTransient<IInventoryApplication, CollegueDiscountApplication>();

            services.AddDbContext<DiscountContext>(x=>x.UseSqlServer(connectionString));
        }
    }
}
