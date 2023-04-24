using InventoryApplication.Infrastucure.EfCore.Mapping;
using InventoryManagment.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;


namespace InventoryApplication.Infrastucure.EfCore
{
    public class InventoryContext:DbContext
    {
        public DbSet<Inventory> Inventory { get; set; }
        public InventoryContext(DbContextOptions<InventoryContext> options):base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(InventoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
