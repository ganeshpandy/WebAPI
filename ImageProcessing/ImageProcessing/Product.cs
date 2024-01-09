namespace ImageProcessing
{
    public class Product
    {
        public int ImgId { get; set; }
        public string? Customers { get; set; }
        public string ProductType { get; set; }
        public string ProductModel { get; set; }
        public string ImgName { get; set; }
        public IFormFile? files { get; set; }
        

    }
    public class Customer
    {
        public int CID { get; set; }
        public string? CustomerName { get; set; }
 
    }
    public class common
    {
        public Product _product { get; set; }
        public Customer _Customer { get; set; }
        public List<Customer> _lCustomer { get; set; }
    }
}
