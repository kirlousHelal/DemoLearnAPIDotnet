using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day3.Models;

namespace Day3.Repository
{
    public interface IStudentReopsitory
    {
        public List<Student> GetAllStudents();
       

        public Student? GetStudentById(int id);
        

        public void AddStudent(Student student);
        

        public void UpdateStudent(Student student);
       
        public void DeleteStudent(Student student);
       
        public void Save();
        
        
    }
}