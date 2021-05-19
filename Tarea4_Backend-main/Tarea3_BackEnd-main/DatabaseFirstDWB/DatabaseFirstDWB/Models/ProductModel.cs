using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDWB.Models
{
    public class ProductModel
    {
        public int? idNumber { get; set; }
        public String Name { get; set; }
        public decimal? Price { get; set; }
        public short? Stock { get; set; }
    }
}
