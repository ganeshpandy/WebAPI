using Amazon.Entities.Models;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IOrder<User> user;
        private readonly IOrder<Product> products;
        private readonly IOrder<CartItem> cartItems;
        private readonly IOrder<Invoice> invoices;

        public ProductController(IOrder<User> user, IOrder<Product> products, IOrder<CartItem> cartItems, IOrder<Invoice> invoices)
        {
            this.user = user;
            this.products = products;
            this.cartItems = cartItems;
            this.invoices = invoices;
        }



        //User
        [HttpGet("Getuser")]
        public async Task<IEnumerable<User>> Getuser()
        {
            var result = await user.GetOrder();
            return result;
        }
        [HttpGet("GetUserById")]
        public async Task<User> GetUserById(int id)
        {
            var get = await user.GetByID(id);
            return get;
        }
        [HttpPost("AddUser")]
        public async Task<ActionResult<User>> AddUser(User entity)
        {
            await user.Add(entity);
            return entity;  

            /*if (entity != null)
            {               
                await user.Add(entity);
            }

            return entity;*/
        }
        [HttpPut("UpdateUser")]
        public async Task<ActionResult<User>> UpdateUser(User entity)
        {
            var update = await user.Update(entity);
            return update;
        }
        [HttpDelete("DeleteUser")]
        public async Task DeleteUser(int id) 
        {
            await user.Delete(id);           
        }
        //----------------------------------------products----------------------------------------------        
        [HttpGet("GetProducts")]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var result = await products.GetOrder();
            return result;
        }
        [HttpGet("GetProductByID")]
        public async Task<Product> GetProductByID(int id)
        {
            var get = await products.GetByID(id);
            return get;
        }
        [HttpPost("AddProduct")]
        public async Task<ActionResult<Product>> AddProduct(Product entity)
        {
            await products.Add(entity);
            return entity;

            /*if (entity != null)
            {
                await products.Add(entity);
            }

            return entity;*/
        }
        [HttpPut("UpdateProduct")]
        public async Task<ActionResult<Product>> UpdateProduct(Product entity)
        {
            var update = await products.Update(entity);
            return update;
        }
        [HttpDelete("DeleteProduct")]
        public async Task DeleteProduct(int id)
        {
            await user.Delete(id);
        }


        //--------------------------------------------CartItems------------------------------------------
       
        [HttpGet("GetCartItems")]
        public async Task<IEnumerable<CartItem>> GetCartItems()
        {
            return await cartItems.GetOrder();
        }
        [HttpGet("GetCartItemsById")]
        public async Task<CartItem> GetCartItemsById(int id)
        {
            return await cartItems.GetByID(id);
        }
        [HttpPost("AddCartItems")]
        public async Task<CartItem> AddCartItems(CartItem cartItem)
        {
            return await cartItems.Add(cartItem);
            /*CartItem obj = new CartItem();
            if (cartItem != null)
            {
                obj = await cartItems.Add(cartItem);
            }
            return obj;*/
        }
        [HttpPut("UpdateCartItems")]
        public async Task<CartItem> UpdateCartItems(CartItem cartItem)
        {
            return await cartItems.Update(cartItem);
        }
        [HttpDelete("DeleteCartItems")]
        public async Task<IActionResult> DeleteCartItems(int id)
        {
            if (cartItems != null)
            {
                await cartItems.Delete(id);
                return Ok();
            }
            return BadRequest();
        }

        // Invoice
        
        [HttpGet("GetInvoice")]
        public async Task<IEnumerable<Invoice>> GetInvoice()
        {
            return await invoices.GetOrder();
        }
        [HttpGet("GetInvoiceById")]
        public async Task<Invoice> GetInvoiceById(int id)
        {
            return await invoices.GetByID(id);
        }
        [HttpPost("AddInvoice")]
        public async Task<Invoice> AddInvoice(Invoice invoice)
        {
            return await invoices.Add(invoice);
            /*Invoice obj = new Invoice();
            if (invoice != null)
            {
                obj = await invoices.Add(invoice);
            }
            return obj;*/
        }
        
        [HttpPut("UpdateInvoice")]
        public async Task<Invoice> UpdateInvoice(Invoice invoice)
        {
            var update = await invoices.Update(invoice);
            return update;
        }
        [HttpDelete("DeleteInvoice")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            if (invoices != null)
            {
                await invoices.Delete(id);
                return Ok();
            }
            return BadRequest();
        }
    }
}

