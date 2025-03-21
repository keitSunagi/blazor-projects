using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICoreHTTP.Models
{
    public class Playlist
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Necessário informar o nome da playlist")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        public List<Music> MusicList { get; set; } = new List<Music>();

        public Playlist()
        {
            //Garante que a lista fique vazia.
            MusicList.Clear();
            if(MusicList.Count <= 0)
            {
             
            }

        }
    }
}
