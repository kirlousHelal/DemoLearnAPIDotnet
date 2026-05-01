using System.ComponentModel.DataAnnotations;

namespace Day1.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string CrsName { get; set; }
        public string CrsDesc { get; set; }
        public int Duration { get; set; }
    }
}
