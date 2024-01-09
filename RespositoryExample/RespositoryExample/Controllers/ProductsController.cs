using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Contract;

namespace RespositoryExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _context;

        public ProductsController(IProductRepository context)
        {
            _context = context;
        }
        // GET: api/TrainingStaffs/5
        [HttpGet("GetProducts")]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var pro = await _context.GetProducts();
            return pro;
        }

        // GET: api/Products
        [HttpGet("GetproductById")]
        public async Task<ActionResult<Product>> GetproductById(int productId)
        {
            var pro = await _context.GetProduct(productId);
            return pro;
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            var pro = await _context.AddProduct(product);
            return pro;
        }
        [HttpPut("UpdateProduct")]
        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            var pro = await _context.UpdateProduct(product);
            return pro;
        }
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _context.DeleteProductAsync(id);
            return NoContent();
        }
        
    }
}
