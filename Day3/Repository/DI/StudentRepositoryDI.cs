using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day3.Models;
using Day3.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Day3.Repository
{
    public class StudentRepositoryDI
    {
        private LearnApiContext context;

        public StudentRepositoryDI (LearnApiContext context)
        {
            this.context = context;
        }

        public List<Student> GetAllStudents()
        {
            return context.Students.ToList();
        }

        public Student? GetStudentById(int id)
        {
            return context.Students.Find(id);
        }

        public void AddStudent(Student student)
        {
            context.Students.Add(student);
            // context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            context.Students.Update(student);
            // context.SaveChanges();
        }
        public void DeleteStudent(Student student)
        {
            context.Students.Remove(student);
            // context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }


}
