using System.ComponentModel.DataAnnotations;

namespace Day3.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        public virtual List<Student> Students { get; set; } = new List<Student>();
    }
}


