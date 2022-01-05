using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Models
{
    public class Product
    {
        [Key]
        public int pId { get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public int totalQuantity { get; set; }
        public double UnitPrice { get; set; }
        public DateTime postedOn { get; set; }
        public int userId { get; set; }
        public User User { get; set; }
        public int cId { get; set; }
        public Category Category { get; set; }
    }
}
