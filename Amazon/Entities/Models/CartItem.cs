
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Entities.Models
{
    public  class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        public int Quantity {  get; set; }
        public int Amount {  get; set; }
        public double GrandTotal { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }//fk
        public Product Product { get; set; }
        

    }
}
