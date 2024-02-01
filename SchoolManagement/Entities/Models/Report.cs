using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Report
    {
        public int Id { get; set; }     
        public string StudentName {  get; set; }
        public int RegisterNo {  get; set; }    
        public double TotalMark {  get; set; }
        public double Percentage {  get; set; }
        public string Grade {  get; set; }
        public int MarkDetailId {  get; set; }
        public MarkDetail MarkDetail { get; set; }
    }
}
