using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class MarkDetail
    {
        [Key]
        public int MarkId { get; set; }
        public int Tamil {  get; set; }
        public int English {  get; set; }
        public int Maths { get; set; }
        public int Science {  get; set; }
        public int Social { get; set; }
        
        public int StudentDetailsId {  get; set; }
        public StudentDetails? StudentDetails { get; set; }
    }
}
