using Microsoft.EntityFrameworkCore;
using StudentEntities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEntities.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext() { }
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }
        public virtual DbSet<Student> StudentDetail { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<StudentReports> Report{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Data Source=DESKTOP-EN72J61\\SQLEXPRESS;Initial Catalog=StudentDetails;Integrated Security=True;TrustServerCertificate=True;");
    }
}
