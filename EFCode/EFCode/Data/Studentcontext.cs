using EFCode.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCode.Data
{
    
        public class StudentContext : DbContext
        {
            public StudentContext()
            { }

            public StudentContext(DbContextOptions<StudentContext> options) : base(options)
            {

            }
            public virtual DbSet<Student> Student { get; set; }
            public virtual DbSet<Teacher> Teacher { get; set; }

    }
    }

