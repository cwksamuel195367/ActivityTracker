using System.ComponentModel.DataAnnotations;
namespace ActivityTracker.Models
{
    public class Activities
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        public DateOnly? Date { get; set; }
        public string? Summary { get; set; }
    }
}
