using System;
using System.Collections.Generic;
using Day2.Models;
using Microsoft.EntityFrameworkCore;

namespace Day2.Data;

public partial class LearnApiContext : DbContext
{
    public LearnApiContext()
    {
    }

    public LearnApiContext(DbContextOptions<LearnApiContext> options)
        : base(options)
    {
    } 

    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Server=.;Database=DemoLearnAPI;Trusted_Connection=True;TrustServerCertificate=True;");

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        OnModelCreatingPartial(modelBuilder);
    //    }

    //    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
