using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly ICustomer Customers;
        private readonly IRoom Rooms;
        private readonly IHotel Hotels;
        private readonly ICheckOut CheckOut;

        public HotelController(ICustomer Customers, IRoom Rooms, IHotel Hotels,ICheckOut CheckOut)
        {
            this.Customers = Customers;
            this.Rooms = Rooms;
            this.Hotels = Hotels;
            this.CheckOut= CheckOut;
        }
        [HttpGet("GetHotelDetails")]
        public async Task<IEnumerable<HotelDetail>> GetHotelDetails()
        {
            var get = await Hotels.GetHotelDetails();
            return get;
        }

        [HttpGet("GetCustomerById")]
        public async Task<HotelDetail> GetCustomerById(int roomNo)
        {
            var get = await Hotels.GetCustomerById(roomNo);
            return get;
        }
        [HttpPost("AddHotelDetail")]
        public async Task<HotelDetail> AddHotelDetail(HotelDetail hotelDetail)
        {
            await Hotels.AddHotelDetail(hotelDetail);
            return hotelDetail;
        }
        //===========================================Customercontroller================================================
        [HttpGet("GetCustomers")]
        public async Task<IEnumerable<CustomerDetail>> GetCustomers()
        {
            var get = await Customers.GetCustomers();
            return get;
        }

        [HttpPost("AddCustomer")]
        public async Task<CustomerDetail> AddCustomer(CustomerDetail customerDetail)
        {
            await Customers.AddCustomer(customerDetail);
            return customerDetail;
        }
        
        [HttpPut("UpdateCustomer")]
        public async Task<CustomerDetail> UpdateCustomer(CustomerDetail customerDetail)
        {
            var update = await Customers.UpdateCustomer(customerDetail);
            return update;
        }
        [HttpDelete("DeleteCustomer")]
        public async Task DeleteCustomer(int customerNo)
        {
            await Customers.DeleteCustomer(customerNo);
        }
        //===========================================Roomcontroller================================================

        [HttpGet("GetRooms")]
        public async Task<IEnumerable<RoomDetail>> GetRoomById()
        {
            var get = await Rooms.GetRooms();
            return get;
        }
        [HttpPost("AddRoom")]
        public async Task<RoomDetail> AddRoom(RoomDetail roomDetail)
        {
            await Rooms.AddRoom(roomDetail);
            return roomDetail;
        }
        [HttpPut("UpdateRoomDetail")]
        public async Task<RoomDetail> UpdateRoomDetail(RoomDetail roomDetail)
        {
            var update = await Rooms.UpdateRoomDetail(roomDetail);
            return update;
        }
        //===========================================Checkoutcontroller================================================
        [HttpPost("CheckOut-EndPoint")]
        public async Task<Check_Out> Add(Check_Out check_Out)
        {
            await CheckOut.Add(check_Out);
            return check_Out;
        }
    }
}
