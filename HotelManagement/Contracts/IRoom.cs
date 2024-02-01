using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRoom
    {
        Task<IEnumerable<RoomDetail>> GetRooms();
        //Task<RoomDetail> GetRoomById(int roomId);
        Task<RoomDetail> AddRoom(RoomDetail roomDetail);
        Task<RoomDetail> UpdateRoomDetail(RoomDetail roomDetail);       
    }
}
