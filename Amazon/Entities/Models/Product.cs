using Amazon.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Entities.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; } 
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public double SellingPrice { get; set; }
        public int AvaliableQuantity {  get; set; }    

    }
}
