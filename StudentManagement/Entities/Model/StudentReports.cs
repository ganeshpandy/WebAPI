using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEntities.Model
{
    public class StudentReports
    {
        [Key]
        public int Id { get; set; }
        public int MarkId {  get; set; }
        public  Mark? Mark { get; set; }
        public double TotalMark {  get; set; }
        public double Percentage {  get; set; }
        public string? Grade {  get; set; }
    }
}