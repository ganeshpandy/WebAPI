using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Image
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        public ValuesController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        public Task<join> Post([FromForm] Product objFile)
        {
            join obj = new join();
            obj._lCustomer = new List<Customer>();
            obj._Product = new Product();
            try
            {
                obj._lCustomer = new List<Customer>()
                {
                    new Customer()
                    {
                        CustomerName = objFile.Customers,
                        CustomerId = 1,
                    }
                };
                //List<Product> list = JsonConvert.DeserializeObject<List<Product>>(objFile.Products);
                //obj.ListCustomer = list;
                obj._Product.ImgId = objFile.ImgId;
                obj._Product.ImgName = "\\Upload\\" + objFile.files.FileName;
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.ContentRootPath + "\\Upload"))
                    {
                        Directory.CreateDirectory(_environment.ContentRootPath + "\\Upload\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_environment.ContentRootPath + "\\Upload\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(filestream);
                        filestream.Flush();
                        //  return "\\Upload\\" + objFile.files.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Task.FromResult(obj);
        }
    }
}
