using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.DTOs
{
    public class ProductDto
    {
        public int pId { get; set; }
        public int cId { get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public int totalQuantity { get; set; }
        public double UnitPrice { get; set; }
        public DateTime postedOn { get; set; }
        public int userId { get; set; }
    }
}
