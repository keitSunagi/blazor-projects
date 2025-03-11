using EFCoreBlazorAPIStudies.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBlazorAPIStudies.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
            
        }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasKey(p => p.id);
        }
    }
}
