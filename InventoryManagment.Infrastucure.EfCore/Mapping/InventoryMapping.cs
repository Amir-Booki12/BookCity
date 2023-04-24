
using InventoryManagment.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryApplication.Infrastucure.EfCore.Mapping
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventory");
            builder.HasKey(x => x.Id);

            builder.OwnsMany(x => x.Operations, options =>{
                options.ToTable("Operations", "Inventory");
                options.HasKey(x => x.Id);
                options.Property(x=>x.Description).HasMaxLength(800);

                options.WithOwner(x=>x.Inventory)
                .HasForeignKey(x => x.InventoryId);

            });
        }
    }
}
