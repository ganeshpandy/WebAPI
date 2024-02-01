using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICustomer
    {
        Task<IEnumerable<CustomerDetail>> GetCustomers();
        //Task<CustomerDetail> GetCustomerById(int roomId);
        Task<CustomerDetail> AddCustomer(CustomerDetail customerDetail);
        Task<CustomerDetail> UpdateCustomer(CustomerDetail customerDetail);
        Task<CustomerDetail> DeleteCustomer(int roomId);
    }
}
