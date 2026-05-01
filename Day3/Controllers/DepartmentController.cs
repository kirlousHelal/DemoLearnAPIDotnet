using Day3.Data;
using Day3.DTOs;
using Day3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day3.Controllers
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



