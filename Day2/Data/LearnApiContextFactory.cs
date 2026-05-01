using System;
using System.Collections.Generic;
using Day2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Day2.Data;

public partial class LearnApiContextFactory : IDesignTimeDbContextFactory<LearnApiContext>
{
    public LearnApiContext CreateDbContext(string[] args)
    {
      var options = new DbContextOptionsBuilder<LearnApiContext>()
          .UseSqlServer("Server=.;Database=LearnApiDB;Trusted_Connection=True;TrustServerCertificate=True;")
          .Options;
        return new LearnApiContext(options);
    }
}
