

using DiscountManagment.Domain.CollegueDiscount;
using DiscountManagment.Domain.CustomerDiscount;
using DiscountManagment.Infrastucure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DiscountManagment.Infrastucure.EfCore
{
    public class DiscountContext:DbContext
    {
        public DbSet<CustomerDiscount> CustomerDicounts { get; set; }
        public DbSet<CollegueDiscount> CollegueDiscounts { get; set; }
        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CustomerDiscountMapping).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
