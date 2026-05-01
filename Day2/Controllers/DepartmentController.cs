using Day2.Data;
using Day2.DTOs;
using Day2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        LearnApiContext context;
        public DepartmentController(LearnApiContext db)
        {
            this.context = db;
        }

        [HttpGet]
        public ActionResult getAll()
        {
            var depts = context.Departments.ToList();
            if (depts == null) return NotFound();

            var deptdtos = depts.Select(d => new DeptDTO
            {
                Id = d.Id,
                Name = d.Name,
                NumOfStudents = d.Students.Count,
                StudentNames = d.Students.Select(s => s.Name).ToList()
            });

            return Ok(deptdtos);
        }



    }
}
