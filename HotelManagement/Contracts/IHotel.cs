using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IHotel
    {
        Task<IEnumerable<HotelDetail>> GetHotelDetails();
        Task<HotelDetail> GetCustomerById(int roomId);
        Task<HotelDetail> AddHotelDetail(HotelDetail hotelDetail);
        //Task<HotelDetail> UpdateCustomer(CustomerDetail customerDetail);
        //Task<HotelDetail> DeleteCustomer(int customerNo);
    }
}
