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
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public double GrandTotal { get; set; } = 0;


        [ForeignKey("CartItem")]
        public int CartItemId { get; set; }
       
        public CartItem CartItem { get; set; }
        
    }
}
