using System.ComponentModel.DataAnnotations;

namespace EFCoreBlazorAPIStudies.Models
{
    public class Todo
    {
        [Key]
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool isDone { get; set; }
    }
}
