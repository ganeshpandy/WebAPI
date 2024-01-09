using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace College.Models
{
    public class Student
    {
        [Key]
        public int StudId { get; set; }
        public string StudName { get; set; }
        [Required]
        public DateTime DOB { get; set; } = new DateTime();

        public long Phno { get; set; }
        [Required, StringLength(50)]
        public string Email { get; set; }
        [Required, StringLength(50)]
        public string City { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public Gender Gender { get; set; }
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }

    }
}
