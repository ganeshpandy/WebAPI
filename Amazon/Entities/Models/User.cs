
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Entities.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }        
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public long Phno { get; set; }
     }
}
