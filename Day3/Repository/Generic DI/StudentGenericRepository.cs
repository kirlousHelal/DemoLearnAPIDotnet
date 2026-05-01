using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day3.Models;
using Day3.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Day3.Repository
{
    public class StudentGenericRepository<TEntity> where TEntity : class
    {
        private LearnApiContext context;

        public StudentGenericRepository(LearnApiContext context)
        {
            this.context = context;
        }

        public List<TEntity> GetAllStudents()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity? GetStudentById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void AddStudent(TEntity student)
        {
            context.Set<TEntity>().Add(student);
        }

        public void UpdateStudent(TEntity student)
        {
            context.Set<TEntity>().Update(student);
            // context.SaveChanges();
        }
        public void DeleteStudent(TEntity student)
        {
            context.Set<TEntity>().Remove(student);
            // context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }


}
