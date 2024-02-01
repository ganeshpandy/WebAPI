using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEntities.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public  string StudentName { get; set; }
        public  string SchoolName { get; set; }  
        public DateTime DateOfBirth { get; set; }
        public  string Standard {  get; set; }
        public bool IsDeleted {  get; set; }      
    }
}
