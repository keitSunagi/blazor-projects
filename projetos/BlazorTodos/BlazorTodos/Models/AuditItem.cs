using System.ComponentModel.DataAnnotations;

namespace BlazorTodos.Models
{
    public class AuditItem
    {
        public DateTime DeletionDate { get; set; }
        public Todo TodoItem { get; set; }
        [Key]
        public string AuditionId { get; set; }
    }
}
