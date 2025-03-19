using BlzAPIGameStore.Backend.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BlzAPIGameStore.Backend.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "É necessário informa um e-mail para prosseguir.")]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }

    }
}
