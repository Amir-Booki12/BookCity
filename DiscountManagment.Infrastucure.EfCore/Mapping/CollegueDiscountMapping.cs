using DiscountManagment.Domain.CollegueDiscount;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManagment.Infrastucure.EfCore.Mapping
{
    public class CollegueDiscountMapping : IEntityTypeConfiguration<CollegueDiscount>
    {
        public void Configure(EntityTypeBuilder<CollegueDiscount> builder)
        {
            builder.ToTable("CollegueDiscounts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Reason).HasMaxLength(300);
        }
    }
}
