using InventoryManagment.Domain.InventoryAgg;
using InventoryManagment.Infrasctucure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagment.Infrasctucure.EfCore
{
    public class InventoryContext:DbContext
    {

        public DbSet<Inventory> Inventory { get; set; }
        public InventoryContext(DbContextOptions<InventoryContext> options):base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assebmly = typeof(InventoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assebmly);
            base.OnModelCreating(modelBuilder);
        }
    }
}