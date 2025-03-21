using APICoreHTTP.Models;
using Microsoft.EntityFrameworkCore;

namespace APICoreHTTP.Data
{
    public class MusicAppContext : DbContext
    {
        public MusicAppContext(DbContextOptions<MusicAppContext> options) : base(options)
        {}

        public DbSet<Music> Musics { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Music>().HasKey(p => p.Id);
            modelBuilder.Entity<Playlist>().HasKey(p => p.Id);
            
                
        }
    }
}
