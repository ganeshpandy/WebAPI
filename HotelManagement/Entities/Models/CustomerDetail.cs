using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CustomerDetail
    {
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Location {  get; set; }
        public long  Phno { get; set; }        
        public DateTime Check_In { get; set; } 
        public string Check_Out { get; set; } 
        public int TotalAmount {  get; set; }
        public bool IsVacated { get; set; } = false;
        public int RoomDetailId {  get; set; }
        public RoomDetail? RoomDetail { get; set; }
    }
}
