using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day3.Data;
using Day3.Models;

namespace Day3.Repository.unit_of_work
{
    public class UnitOfWork
    {
        LearnApiContext context;
        private StudentGenericRepository<Student>? repoStudent;
        private StudentGenericRepository<Department>? repoDepartment;


        public UnitOfWork(LearnApiContext context)
        {
            this.context = context;
        }


        public StudentGenericRepository<Student> RepoStudent
        {
            get
            {
                if (repoStudent == null)
                {
                    repoStudent = new StudentGenericRepository<Student>(context);
                }
                return repoStudent;
            }
        }

        public StudentGenericRepository<Department> RepoDepartment
        {
            get
            {
                if (repoDepartment == null)
                {
                    repoDepartment = new StudentGenericRepository<Department>(context);
                }
                return repoDepartment;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}