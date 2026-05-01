using Day3.Data;
using Day3.DTOs;
using Day3.Models;
using Day3.Repository;
using Day3.Repository.unit_of_work;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // LearnApiContext context;
        // private StudentRepositoryDI Repos; // Normal Dependency Injection (DI)
        // private StudentRepositoryDIP Repos; // Dependency Inversion Principle (DIP)
        // private StudentGenericRepository<Student> Repos; // Generic Dependency Injection (GDI)
        private UnitOfWork unitOfWork; // Unit of Work (UoW)
        public StudentController(UnitOfWork unitOfWork)
        {
            // this.context = context;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var stds = unitOfWork.RepoStudent.GetAllStudents();

            if (stds == null || stds.Count == 0) return NotFound();

            var stdDTOs = stds.Select(s => new StudentDTO
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                Age = s.Age,
                DeptId = s.DeptId,
            });

            return Ok(stdDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var std = unitOfWork.RepoStudent.GetStudentById(id);

            if (std == null) return NotFound();

            return Ok(std);
        }

        [HttpPost]
        public ActionResult AddStudent(StudentInsertDTO studentDTO)
        {
            if (studentDTO == null) return BadRequest();

            var student = new Student
            {
                Name = studentDTO.Name,
                Age = studentDTO.Age,
                Address = studentDTO.Address,
                DeptId = studentDTO.DeptId
            };

            unitOfWork.RepoStudent.AddStudent(student);
            unitOfWork.Save();
            return Created("", studentDTO);
        }

    }
}


