using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Data
{
    public class ContextDB:DbContext
    {
        public ContextDB() { }

        public ContextDB(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<StudentDetails> Students { get; set; }
        
        public virtual DbSet<MarkDetail> Marks { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=StudentReport;Integrated Security=True;TrustServerCertificate=True;");
    }
}

