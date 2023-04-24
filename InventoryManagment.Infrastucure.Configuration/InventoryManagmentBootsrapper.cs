

using InventoryApplication.Infrastucure.EfCore.Repository;
using InventoryManagment.Application.Contract.Inventory;
using InventoryManagment.Domain.InventoryAgg;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryApplication.Infrastucure.Configuration
{
    public class InventoryManagmentBootsrapper
    {

        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IInventoryApplication, InventoryApplication>();
        }
    }
}
