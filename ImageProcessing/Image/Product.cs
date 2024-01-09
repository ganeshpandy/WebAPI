namespace Image
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
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

    }
    public class join 
    {
        public Product _Product { get; set; }
        public Customer _Customer { get; set; }
        public List<Customer> _lCustomer { get; set; }
    }
}
