using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageProcessing
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        public ImageUploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        
        [HttpPost]
        public Task<common> Post([FromForm] Product objFile)
        {
            common obj = new common();
            obj._lCustomer = new List<Customer>();
            obj._product = new Product();
            try
            {
                obj._lCustomer = new List<Customer>() 
                { 
                    new Customer() 
                    { 
                        CustomerName = objFile.Customers,
                        CID = 1,                       
                    }
                };
                //List<Product> list = JsonConvert.DeserializeObject<List<Product>>(objFile.Products);
                //obj.ListCustomer = list;
                obj._product.ImgId= objFile.ImgId;
                obj._product.ImgName = "\\Upload\\" + objFile.files.FileName;
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
