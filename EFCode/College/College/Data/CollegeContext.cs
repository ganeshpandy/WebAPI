using College.Models;
using Microsoft.EntityFrameworkCore;

namespace College.Data
{
    public class CollegeContext : DbContext
    {
        public CollegeContext()
        { }
        public CollegeContext(DbContextOptions<CollegeContext> options) : base(options)
        {

        }
        public virtual DbSet<Student> _student { get; set; }
        public virtual DbSet<Staff> _staff { get; set; }
    }
}
