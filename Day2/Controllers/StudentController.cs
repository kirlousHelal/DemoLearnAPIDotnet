using Day2.Data;
using Day2.DTOs;
using Day2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        LearnApiContext context;
        public StudentController(LearnApiContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult GetAll()
        {

            var stds = context.Students.ToList();

            var stdDTOs = stds.Select(s => new StudentDTO
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                Age = s.Age,
                DeptId = s.DeptId,
            });



            if (stds == null || stds.Count == 0)
            {
                return NotFound();
            }
            return Ok(stdDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var std = context.Students.Find(id);

            if (std == null) return NotFound();

            return Ok(std);
        }

        [HttpPost]
        public ActionResult AddStudent(StudentInsertDTO studentDTO)
        {
            if (studentDTO == null) return BadRequest();


            context.Students.Add(new Student
            {
                Address = studentDTO.Address,
                Age = studentDTO.Age,
                DeptId = studentDTO.DeptId,
                Name = studentDTO.Name,
            });

            context.SaveChanges();
            return Created("", studentDTO);
        }

    }
}
