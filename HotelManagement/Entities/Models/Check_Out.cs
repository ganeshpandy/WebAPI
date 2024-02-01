using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Check_Out
    {
        public int Id { get; set; }
        public string CustomerName {  get; set; }             
        public string Status {  get; set; }
        public int CustomerDetailId { get; set; }
        public CustomerDetail? CustomerDetail { get; set; }
    }
}
