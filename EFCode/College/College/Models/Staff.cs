using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace College.Models
{
    public class Staff
    {
        [ForeignKey("Student")]
        public int StaffId { get; set; }
        [Required, StringLength(50)]
        public string StaffName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public Subject Subject { get; set; }
        //public virtual ICollection<Staff> Students { get; set; } = new List<Staff>();
    }
}
