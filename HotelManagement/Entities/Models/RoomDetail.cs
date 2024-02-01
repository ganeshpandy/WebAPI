using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class RoomDetail
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public RoomType Roomtype { get; set; }
        public enum RoomType
        { 
            AC,
            NonAC
        }
        public double Rent {  get; set; }
       
        public bool IsBooked {  get; set; }= false;

        public int HotelDetailId { get; set; }
        public HotelDetail? HotelDetail { get; set; }
    }
}
