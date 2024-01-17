using Amazon.Entities.Data;
using Amazon.Entities.Models;
using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PatternRepository : IOrder<User>,IOrder<Product>,IOrder<CartItem>,IOrder<Invoice>
    {
        private readonly ProductContext _context;

        public PatternRepository(ProductContext context)
        {
            _context = context;
        }
        //----------------------------------------User----------------------------------------------     
        public async Task<User> Add(User entity)
        {
            var result = await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

      

        public async Task<User> Delete(int id)
        {
            var result = await _context.Users
              .FirstOrDefaultAsync(C => C.UserId == id);

            if (result != null)
            {
                _context.Users.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }

        public async Task<User> GetByID(int Id)
        {
            return await _context.Users.FirstOrDefaultAsync(o => o.UserId == Id);
        }

        public async Task<IEnumerable<User>> GetOrder()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Update(User entity)
        {
            var result = await _context.Users
                     .FirstOrDefaultAsync(C => C.UserId == entity.UserId);

            if (result != null)
            {
                result.UserId = entity.UserId;
                result.UserName = entity.UserName;
                result.Address = entity.Address;
                result.Email = entity.Email;
                result.Address=entity.Address;
                result.Phno = entity.Phno;
                return result;
            }
            return null;
        }
        //----------------------------------------products----------------------------------------------     
        public async Task<Product> Update(Product product)
        {
            var updateProduct = await _context.Products.FirstOrDefaultAsync(e => e.ProductId == product.ProductId);

            if (updateProduct != null)
            {
                updateProduct.ProductName = product.ProductName;
                updateProduct.SellingPrice = product.SellingPrice;
                updateProduct.AvaliableQuantity = product.AvaliableQuantity;

               /* var CartItem = await _context.CartItems.FirstOrDefaultAsync(c => c.CartItemId == product.ProductId);
                if (CartItem != null)
                {
                    var products = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == CartItem.ProductId);
                    updateProduct.AvaliableQuantity = product.AvaliableQuantity - CartItem.Quantity;
                }*/
                await _context.SaveChangesAsync();
                return updateProduct;
            }
            throw new Exception("Id not found");
        }
        public async Task<Product> Add(Product entity)
        {
            var result = await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        async Task<Product> IOrder<Product>.GetByID(int Id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(o => o.ProductId == Id);

            if (product != null)
            {
                product.AvaliableQuantity = (int)CalculateProductQuantity(product.ProductId);
            }

            return product;
        }

        async Task<IEnumerable<Product>> IOrder<Product>.GetOrder()
        {
            return await _context.Products.ToListAsync();
        }
        
         async Task<Product> IOrder<Product>.Delete(int id)
        {
            var result = await _context.Products
              .FirstOrDefaultAsync(C => C.UserId == id);

            if (result != null)
            {
                _context.Products.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }
        
        //----------------------------------------Cart item----------------------------------------------     
        async Task<IEnumerable<CartItem>> IOrder<CartItem>.GetOrder()
        {
            return await _context.CartItems.ToListAsync();
        }
        async Task<CartItem> IOrder<CartItem>.GetByID(int Id)
        {
            return await _context.CartItems.FirstOrDefaultAsync(e => e.CartItemId == Id);
        }
        public async Task<CartItem> Add(CartItem cartItem)
        {
            var addProduct = await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();
            return addProduct.Entity;
        }
        public async Task<CartItem> Update(CartItem cartItem)
        {
            var updateCartItem = await _context.CartItems.FirstOrDefaultAsync(e => e.CartItemId == cartItem.CartItemId);

            if (updateCartItem != null)
            {
                updateCartItem.Quantity = cartItem.Quantity;

                await _context.SaveChangesAsync();
                return updateCartItem;
            }
            throw new Exception("Id not found");
        }        
        async Task<CartItem> IOrder<CartItem>.Delete(int id)
        {
            var result = await _context.CartItems
             .FirstOrDefaultAsync(C => C.CartItemId == id);

            if (result != null)
            {
                _context.CartItems.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }

        // Invoice
        async Task<IEnumerable<Invoice>> IOrder<Invoice>.GetOrder()
        {
            return await _context.Invoices.ToListAsync();
        }
        async Task<Invoice> IOrder<Invoice>.GetByID(int id)
        {
            var invoice = await _context.Invoices.FirstOrDefaultAsync(e => e.InvoiceId == id);

            if (invoice != null)
            {                
                invoice.GrandTotal = CalculateGrandTotal(invoice);
            }

            return invoice;
        }
        public async Task<Invoice> Add(Invoice order)
        {
            var addInvoice = await _context.Invoices.AddAsync(order);
            await _context.SaveChangesAsync();
            return addInvoice.Entity;
        }
        public Task<Invoice> Update(Invoice entity)
        {
            throw new NotImplementedException();
        }
        async Task<Invoice> IOrder<Invoice>.Delete(int id)
        {
            var result = await _context.Invoices
             .FirstOrDefaultAsync(C => C.InvoiceId == id);

            if (result != null)
            {
                _context.Invoices.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }

        public double CalculateGrandTotal(Invoice order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            double grandTotal = order.GrandTotal;

            if (order.CartItem != null)
            {
                grandTotal += order.CartItem.Quantity * order.CartItem.Product.SellingPrice;
            }

            return grandTotal;
        }

        public double CalculateProductQuantity(int productId)
        {
            var cartItem = _context.CartItems.FirstOrDefault(c => c.CartItemId.Equals(productId));

            if (cartItem == null)
            {
                throw new ArgumentException($"CartItem with ID {productId} not found.");
            }

            return cartItem.Product.AvaliableQuantity - cartItem.Quantity;
        }

    }

}

