using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class StudentDetails
    {
        [Key]
        public int ID { get; set; }                
        public string StudentName {  get; set; }
        public DateTime DOB { get; set; }= DateTime.Now;
       
        public int Standard {  get; set; }
        public long PhoneNumber {  get; set; }
       


    }
}
