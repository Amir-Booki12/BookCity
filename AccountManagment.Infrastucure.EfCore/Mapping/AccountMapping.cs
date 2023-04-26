using AccountManagment.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace AccountManagment.Infrastucure.EfCore.Mapping
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Mobile).IsRequired().HasMaxLength(12);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(600);
            builder.Property(x => x.ProfilePhoto).IsRequired(false).HasMaxLength(100);


            builder.HasOne(x => x.Role)
            .WithMany(x => x.Accounts)
            .HasForeignKey(x => x.RoleId);

        }
    }
}
