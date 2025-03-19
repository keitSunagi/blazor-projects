using BlzAPIGameStore.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace BlzAPIGameStore.Backend.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {
           
        }

        //DbSets(Tabelas)

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(p => p.Id);
            modelBuilder.Entity<Customer>().HasKey(p => p.Id);

           
            
        }
    }
}
