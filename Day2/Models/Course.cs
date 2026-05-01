using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Day2.Models;

public partial class Course
{
    [Key]
    public int Id { get; set; }

    public string CrsName { get; set; } = null!;

    public string CrsDesc { get; set; } = null!;

    public int Duration { get; set; }
}
