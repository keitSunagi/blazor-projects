using BlazorTodos.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorTodos.Data
{
    public class AppTodoContext : DbContext
    {
        public AppTodoContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<AuditItem> AuditionTodos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasKey(p => p.Id);
            modelBuilder.Entity<AuditItem>().HasKey(p => p.AuditionId);
            

        }
    }
}
