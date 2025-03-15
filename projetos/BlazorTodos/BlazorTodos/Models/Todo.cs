using System.ComponentModel.DataAnnotations;

namespace BlazorTodos.Models
{
    public class Todo
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "Necessário informar ao menos o título")]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EndLine { get; set; }

        public Todo()
        {
            
        }

        public Todo(string id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}
