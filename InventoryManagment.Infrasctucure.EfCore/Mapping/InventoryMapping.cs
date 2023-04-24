
using InventoryManagment.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagment.Infrasctucure.EfCore.Mapping
{
    internal class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventory");
            builder.HasKey(x => x.Id);

            builder.OwnsMany(x => x.Operations, config =>
            {
                config.ToTable("OperationInventory");
                config.HasKey(x => x.Id);
                config.Property(x=>x.Description).HasMaxLength(500);

                config.WithOwner(x => x.Inventory).HasForeignKey(x => x.InventoryId);
            });
               
        }
    }
}
