using InventoryManagment.Application.Contract.Inventory;
using InventoryManagment.Application.Inventory;
using InventoryManagment.Domain.InventoryAgg;
using InventoryManagment.Infrasctucure.EfCore;
using InventoryManagment.Infrasctucure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagment.Infrasctucure.Configuration
{
    public class InventoryManagmentBootsrapper
    {
        public static void Configure(IServiceCollection services ,string connenctionString)
        {
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IInventoryApplication, InventoryApplication>();


            services.AddDbContext<InventoryContext>(x=>x.UseSqlServer(connenctionString));


        }
    }
}