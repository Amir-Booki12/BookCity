
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManagment.Infrastucure.EfCore.Mapping
{
    public class CustomerDiscountMapping : IEntityTypeConfiguration<Domain.CustomerDiscount.CustomerDiscount>
    {
        public void Configure(EntityTypeBuilder<Domain.CustomerDiscount.CustomerDiscount> builder)
        {
            builder.ToTable("CustomerDiscounts");
            builder.HasKey(x => x.Id);
            
            builder.Property(x=>x.Reason).HasMaxLength(300);
        }
    }
}
