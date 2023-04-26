

using CommentManagment.Domain.CommentAgg;
using CommentManagment.Infrastucure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;


namespace CommentManagment.Infrastucure.EfCore
{

    
    public class CommentContext:DbContext
    {
        public CommentContext(DbContextOptions<CommentContext> options):base(options)
        {
            
        }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly= typeof(CommentMapping).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(assembly); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
