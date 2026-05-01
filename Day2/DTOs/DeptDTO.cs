namespace Day2.DTOs
{
    public class DeptDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int NumOfStudents { get; set; }

        public List<string> StudentNames { get; set; } = new List<string>();
    }
}
