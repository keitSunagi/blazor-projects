using System.ComponentModel.DataAnnotations;

namespace APICoreHTTP.Models
{
    public enum MusicGenre : int
    {
        NoGenre = 0,
        Classic = 1,
        Rock = 2,
        Eletronic = 3,
        Country = 4,
        Trap = 5,
        Rap = 6

    }
    public class Music
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage =  "Necessário informar o nome da música")]
        public string Name { get; set; } = string.Empty;
        [MaxLength(100)]
        [Required(ErrorMessage = "Necessário informar o nome do artista da música")]
        public string Artist { get; set; } = string.Empty;
        public string UrlMusic { get; set; } = string.Empty;
        public MusicGenre Genre { get; set; } = MusicGenre.NoGenre;

        public Music()
        {
            Id = Guid.NewGuid();
        }

        public Music(string name, string artist, string urlMusic, MusicGenre? genre)
        {
            Id = Guid.NewGuid();
            Name = name;
            Artist = artist;
            UrlMusic = urlMusic;
            
            if (genre is null) Genre = MusicGenre.NoGenre;
            else Genre = (MusicGenre)genre;
        }
    }
}
