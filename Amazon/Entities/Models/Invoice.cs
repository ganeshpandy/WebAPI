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
        public string InvoiceUserName { get; set; }
        public string InvoiceCategoryName {  get; set; }
        public string InvoiceProductName {  get; set; }
        public double InvoiceGrandTotal { get; set; } 
        public int UserId {  get; set; }
        public User User { get; set; }       
        public int CartItemId { get; set; }       
        public CartItem CartItem { get; set; }
        
    }
}
