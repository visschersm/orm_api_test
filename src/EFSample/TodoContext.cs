using Microsoft.EntityFrameworkCore;
using MTech.Domain;

namespace MTech.EFSample
{
    public class TodoContext : DbContext
    {
        public TodoContext()
            : base()
        {
            
        }

        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TodoItem> TodoItem => Set<TodoItem>();
    }
}