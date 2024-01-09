using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EFCode.Models
{
    public class Teacher
    {
        [ForeignKey("Student")]
        public int TeacherId { get; set; }
        [Required, StringLength(50)]
        public string TeacherName { get; set; }   
        public Subject Subject { get; set; }
        public Student Student { get; set; }
    }
}
