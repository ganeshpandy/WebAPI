using Amazon.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IOrder<T>
    {
        Task<IEnumerable<T>> GetOrder();
        Task<T> GetByID(int Id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        double CalculateGrandTotal(Invoice order);
        double CalculateProductQuantity(int productId);
    }
}
