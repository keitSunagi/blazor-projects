using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlzAPIGameStore.Backend.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        [Required]
        public User UserId { get; set; }

        public Customer() { }
        
        public Customer(string username)
        {
            Id = Random.Shared.Next(0, 9999);
            if(username is null || username == "")
            {
                username = "GUEST" + Id.ToString();
            }
        }

    }
}
