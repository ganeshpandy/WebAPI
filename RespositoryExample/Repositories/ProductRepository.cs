using Contract;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _product;
        public ProductRepository(ProductContext appDbContext)
        {
            this._product = appDbContext;
        }
        public async Task<Product> GetProducts(int productId)
        {
            return await _product.products
                .FirstOrDefaultAsync(e => e.ProductId == productId);
        }
        public async Task<Product> AddProduct(Product product)
        {            
            var result = await this._product.products.AddAsync(product);
            await this._product.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteProductAsync(int productId)
        {
            var result = await _product.products
                .FirstOrDefaultAsync(p => p.ProductId == productId);
            if (result != null)
            {
                _product.products.Remove(result);
                await _product.SaveChangesAsync();
            }
        }

        public async Task<Product> GetProduct(int productId)
        {
            return await _product.products.FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _product.products.ToListAsync();
        }

       /* public void IProductRepository.DeleteProductAsync(int productId)
        {
            throw new NotImplementedException();
        }*/

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await _product.products.FirstOrDefaultAsync(p => p.ProductId == product.ProductId);                          
            if (result != null)
            {
                result.ProductType = product.ProductType;
                result.ProductId = product.ProductId;
                result.ProductModel= product.ProductModel;
                await _product.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
