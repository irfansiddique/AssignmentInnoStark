using Microsoft.EntityFrameworkCore;
using innoStarkAssignment.Core.Model;
using innoStarkAssignment.Data.Configurations;

namespace innoStarkAssignment.Data
{
     public class InnoStarkDbContext : DbContext
    {
        public InnoStarkDbContext(DbContextOptions<InnoStarkDbContext> options)
           : base(options)
        { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new BlogConfiguration());

            builder
                .ApplyConfiguration(new CategoryConfiguration());
        }
    }
}