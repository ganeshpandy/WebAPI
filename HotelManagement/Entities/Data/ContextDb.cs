using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Data
{
    public class ContextDb:DbContext
    {
        public ContextDb() { }

        public ContextDb(DbContextOptions options) : base(options)
        {
        }
       
        public virtual DbSet<CustomerDetail> Customers { get; set; }

        public virtual DbSet<HotelDetail> Hotels { get; set; }
        public virtual DbSet<RoomDetail> Rooms { get; set; }
        public virtual DbSet<Check_Out> CheckOut { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Hotel;Integrated Security=True;TrustServerCertificate=True;");
        

    }
}
