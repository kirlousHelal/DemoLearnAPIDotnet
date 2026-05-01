using Day1.Models;
using Microsoft.EntityFrameworkCore;

namespace Day1.Data
{
    public class LearnAPIContext :DbContext

    {
        public LearnAPIContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }
        public LearnAPIContext()
        {
            
        }

        public DbSet<Course> Courses { get; set; }
    }
}
