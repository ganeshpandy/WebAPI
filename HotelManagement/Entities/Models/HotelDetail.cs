using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class HotelDetail
    {
        [Key]
        public int Id { get; set; }
        public string HotelName {  get; set; }

        public int TotalRooms { get; set; }
        public int RoomAvailablity {  get; set; }
        


    }
}
