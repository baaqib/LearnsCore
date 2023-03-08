using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learns.Model.Classes
{
    public class LearnsContext : DbContext
    {
        public LearnsContext(DbContextOptions<LearnsContext> options) : base(options) { }

        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
