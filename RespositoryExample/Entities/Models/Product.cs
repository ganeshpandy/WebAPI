using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public string ProductModel { get; set; }
        public long Phno { get; set; }
        public DateTime DOD { get; set; } = new DateTime();
        public int Amount { get; set; }

    }
}
