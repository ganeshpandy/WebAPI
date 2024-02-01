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
    public class PatternRepository : IOrder<User>, IOrder<Product>, IOrder<CartItem>, IOrder<Invoice>
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
                result.Address = entity.Address;
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
                await _context.SaveChangesAsync();
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
              .FirstOrDefaultAsync(C => C.ProductId == id);

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
            var result = await _context.CartItems.AddAsync(cartItem);
            if (cartItem != null && cartItem.Product != null)
            {                
                cartItem.Amount = (int)cartItem.Product.SellingPrice;
            }            
            //await CalculateGrandTotal((int)cartItem.GrandTotal);
            await _context.SaveChangesAsync();            
            await CalculateGrandTotal(cartItem.CartItemId);

            return result.Entity;
        }
        public async Task<CartItem> Update(CartItem cartItem)
        {
            var updateCartItem = await _context.CartItems.FirstOrDefaultAsync(e => e.CartItemId == cartItem.CartItemId);

            if (updateCartItem != null)
            {
                updateCartItem.Quantity = cartItem.Quantity;
                await _context.SaveChangesAsync();

                // Calculate the amount and update the GrandTotal in the associated Invoice
                await CalculateGrandTotal(cartItem.CartItemId);

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
            //var result= await _context.CartItems.FirstOrDefaultAsync(e => e.CartItemId == Id);
            var invoice = await _context.Invoices
                .Include(p => p.User)
                .Include(i => i.CartItem)
                    .ThenInclude(ci => ci.Product) // Include the Product related to the CartItem
                .FirstOrDefaultAsync(i => i.InvoiceId == id);

            // Additional logic to calculate properties based on related entities
            if (invoice != null && invoice.CartItem != null && invoice.CartItem.Product != null)
            {
                // Populate the Invoice properties based on related entities
                invoice.InvoiceUserName = invoice.User?.UserName; 
                invoice.InvoiceCategoryName = invoice.CartItem.Product.CategoryName;
                invoice.InvoiceProductName = invoice.CartItem.Product.ProductName;
            }

            return invoice;
        }
        public async Task<Invoice> Add(Invoice order)
        {
            // Calculate GrandTotal based on the CartItem properties
            //order.GrandTotal = (double)order.CartItem.Amount;

            // Add the Invoice to the context
            var result = await _context.Invoices.AddAsync(order);
            
            /* if (order.InvoiceGrandTotal == null)
             {
                 order.InvoiceGrandTotal = order.CartItem.GrandTotal;
             }
             else 
             {
                 throw new Exception("Invalid Amount");
             }*/

            // Populate the Invoice properties based on related entities
            if (order.CartItem != null && order.CartItem.Product != null && order.User != null)
            {
                result.Entity.InvoiceUserName = order.User.UserName;
                result.Entity.InvoiceCategoryName = order.CartItem.Product.CategoryName;
                result.Entity.InvoiceProductName = order.CartItem.Product.ProductName;
                
                result.Entity.InvoiceGrandTotal = order.CartItem.GrandTotal;
                //cartItem.Amount = (decimal)cartItem.Product.SellingPrice;

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();

            return result.Entity;
            
            
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
        //CalculateGrandTotal
        public async Task CalculateGrandTotal(int cartItemId)
        {
            var cartItem = await _context.CartItems
                       .Include(c => c.Product)
                       .FirstOrDefaultAsync(c => c.CartItemId == cartItemId);
            if(cartItem != null)
            {
                cartItem.GrandTotal = (double)(cartItem.Quantity * (decimal)cartItem.Product.SellingPrice);
            }
            

            await _context.SaveChangesAsync();
            

            /*if (cartItem != null && cartItem.Product != null)
            {
                var invoice = await _context.Invoices.FirstOrDefaultAsync(i => i.CartItemId == cartItemId);

                if (invoice != null)
                {                    
                    //cartItem.Amount = (decimal)cartItem.Product.SellingPrice;       
                }

            }*/
            await _context.SaveChangesAsync();
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

