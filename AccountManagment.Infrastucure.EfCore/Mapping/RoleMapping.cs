using AccountManagment.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace AccountManagment.Infrastucure.EfCore.Mapping
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);

            builder.HasMany(x => x.Accounts)
            .WithOne(x => x.Role)
            .HasForeignKey(x => x.RoleId);
        }
    }
}
