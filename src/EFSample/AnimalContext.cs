using DomainLayer;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EFSample
{
    public class AnimalContext : DbContext
    {
        public AnimalContext()
            : base()
        {

        }

        public AnimalContext(DbContextOptions<AnimalContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configure this to run migrations
                optionsBuilder.UseSqlServer();
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Animal> Animal => Set<Animal>();
        public DbSet<Dog> Dog => Set<Dog>();
        public DbSet<Cow> Cow => Set<Cow>();
    }
}
