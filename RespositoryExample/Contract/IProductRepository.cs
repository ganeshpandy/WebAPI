using Entities.Models;

namespace Contract
{
    public interface IProductRepository 
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int productId);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProductAsync(int productId);
    }
}
