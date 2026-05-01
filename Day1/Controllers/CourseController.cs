using Day1.Data;
using Day1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        LearnAPIContext dbcontext;
        public CourseController(LearnAPIContext learnAPIContext)
        {
            this.dbcontext = learnAPIContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var courses = dbcontext.Courses.ToList();

            if (courses.Count == 0 || courses == null) return NotFound();

            return Ok(courses);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var course = dbcontext.Courses.Find(id);

            if (course == null) return NotFound();
            dbcontext.Courses.Remove(course);
            dbcontext.SaveChanges();
            return Ok(course);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, Course course)
        {
            var cs = dbcontext.Courses.Find(id);
            if (cs == null) return NotFound();
            if (cs.Id != course.Id) return BadRequest();
            dbcontext.Courses.Update(course);
            dbcontext.SaveChanges();
            return NoContent();
        }


        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            if (course == null) return BadRequest();
            dbcontext.Courses.Add(course);
            dbcontext.SaveChanges();
            return CreatedAtAction("GetAll", new { id = course.Id }, course);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetCourse(int id)
        {
            var course = dbcontext.Courses.Find(id);
            if (course == null) return NotFound();

            return Ok(course);

        }

        [HttpGet("{name:alpha}")]
        public IActionResult GetCourse(string name)
        {
            var course = dbcontext.Courses.FirstOrDefault(c => c.CrsName == name);
            if (course == null) return NotFound();

            return Ok(course);

        }
    }
}
