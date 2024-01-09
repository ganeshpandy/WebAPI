using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EFCode.Models
{
    public class Student
    {
        [Key]
        public int StudId { get; set; }
        [Required]
        [StringLength(50)]
        public string StudName { get; set; }
        public DateTime DOB { get; set; } = new DateTime();      
        
        public long Phno { get; set; }
        [Required, StringLength(50)]
        public string Email { get; set; }
        [Required, StringLength(50)]
        public string City { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public Gender Gender { get; set; }

    }
}
