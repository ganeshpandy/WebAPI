using Contracts;
using Entities.Data;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Repository
{
    public class HotelRepository : ICustomer, IHotel, IRoom,ICheckOut
    {
        private readonly ContextDb _context;

       
        public HotelRepository(ContextDb context)
        {
            _context = context;
        }
        public async Task<IEnumerable<HotelDetail>> GetHotelDetails()
        {
            return await _context.Hotels.ToListAsync();
        }
        async Task<HotelDetail> IHotel.GetCustomerById(int roomId)
        {
            return await _context.Hotels.FirstOrDefaultAsync(h => h.Id == roomId);
        }
        public async Task<HotelDetail> AddHotelDetail(HotelDetail hotelDetail)
        {
            hotelDetail.TotalRooms = 10;
            hotelDetail.RoomAvailablity = hotelDetail.TotalRooms;
            var result = await _context.Hotels.AddAsync(hotelDetail);
            
            await _context.SaveChangesAsync();
            return result.Entity;
        }


        //===========================================CustomerRepository===============================================
        public async Task<IEnumerable<CustomerDetail>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task<CustomerDetail> GetCustomerById(int roomId)
        {
            return await _context.Customers.FirstOrDefaultAsync(o => o.RoomDetailId == roomId);
        }
        public async Task<CustomerDetail> AddCustomer(CustomerDetail customerDetail)
        {
            var GetRooms = await _context.Rooms.FirstOrDefaultAsync(C => C.Id == customerDetail.RoomDetailId);
            var GetHotels = await _context.Hotels.FirstOrDefaultAsync(C => C.Id == customerDetail.RoomDetailId);
            var GetCustomer = await _context.Customers.FirstOrDefaultAsync(C => C.Id == customerDetail.RoomDetailId);


            
            if (GetRooms!=null && GetCustomer !=null && GetRooms.IsBooked==false ) 
            {
                GetRooms.IsBooked = true;
                GetCustomer.IsVacated = false;
                GetCustomer.Check_In = DateTime.Now;
                string changeformat = GetCustomer.Check_In.ToString("yyyy-MM-dd");
                DateTime checkout = DateTime.Parse(customerDetail.Check_Out);

                TimeSpan timeSpan = checkout.Date - GetCustomer.Check_In.Date;

                int days = timeSpan.Days;

                customerDetail.TotalAmount = (int)(days * GetRooms.Rent);
            }
            var result = await _context.Customers.AddAsync(customerDetail);
            await _context.SaveChangesAsync();
            if (GetHotels != null) 
            {
                GetHotels.RoomAvailablity--;                
            }

            await _context.SaveChangesAsync();
            return result.Entity;
        }
      
        public async Task<CustomerDetail> UpdateCustomer(CustomerDetail customerDetail)
        {
            var result = await _context.Customers
                   .FirstOrDefaultAsync(C => C.Id == customerDetail.Id);
            if (result != null)
            {
                result.CustomerName = customerDetail.CustomerName;
                result.Location = customerDetail.Location;
                result.Phno = customerDetail.Phno;

                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
        async Task<CustomerDetail> ICustomer.DeleteCustomer(int roomId)
        {
            var result = await _context.Customers
               .FirstOrDefaultAsync(C => C.RoomDetailId == roomId);

            if (result != null)
            {
                _context.Customers.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }

        //===========================================RoomRepository===============================================
        public async Task<IEnumerable<RoomDetail>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<RoomDetail> GetRoomById(int roomId)
        {
            return await _context.Rooms.FirstOrDefaultAsync(o => o.Id == roomId);
        }

        public async Task<RoomDetail> AddRoom(RoomDetail roomDetail)
        {
            var GetHotel = await _context.Hotels.FirstOrDefaultAsync(t=> t.Id == roomDetail.HotelDetailId);
            if (_context.Rooms.Count() < GetHotel.TotalRooms)
            {
                if (roomDetail.Roomtype == 0)
                {
                    roomDetail.Rent = 1500;
                }
                else
                {
                    roomDetail.Rent = 1000;
                }
            }
            var result = await _context.Rooms.AddAsync(roomDetail);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public  Task<RoomDetail> UpdateRoomDetail(RoomDetail roomDetail)
        {
            throw new NotImplementedException();
        }

        public async Task<Check_Out> Add(Check_Out check_Out)
        {
                if (check_Out != null)
                {
                    check_Out.Status = "CheckedOut Successfully";
                    var GetCustomer = await _context.Customers.FirstOrDefaultAsync(t => t.Id.Equals(check_Out.CustomerDetailId));
                    if (GetCustomer != null)
                    {
                        var GetRoom = await _context.Rooms.FirstOrDefaultAsync(t => t.Id.Equals(GetCustomer.RoomDetailId));
                        if (GetCustomer != null && GetRoom != null)
                        {
                            GetCustomer.IsVacated = true;
                            GetRoom.IsBooked = false;

                            var GetHotel = await _context.Hotels.FirstOrDefaultAsync(t => t.Id.Equals(GetRoom.HotelDetailId));
                            if (GetHotel != null)
                            {
                                GetHotel.RoomAvailablity++;
                                var addcheckOut = await _context.AddAsync(check_Out);
                                await _context.SaveChangesAsync();
                                return addcheckOut.Entity;
                            }
                        }
                    }
                }
                return null;
            }
            
        }
    }


