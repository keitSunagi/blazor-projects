using System.ComponentModel.DataAnnotations;

namespace BlzAPIGameStore.Backend.Models
{
    public class Item
    {
        [Key]
        public string Id { get; set; } = string.Empty;
        public int CodeItem { get; set; }
        [Required(ErrorMessage = "Necessário nome do item.")]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Necessário descrição do item.")]
        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;
        public float Price { get; set; }

    }
}
