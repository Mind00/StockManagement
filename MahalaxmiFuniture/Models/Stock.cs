using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Models
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }
        public int cId { get; set; }
        public int pId { get; set; }
        public int quantity { get; set; }
        public float saleUnitPrice { get; set; }
        public float currentPurchaseUnitPrice { get; set; }
        public DateTime manufactureDate { get; set; }
        public string description { get; set; }
        public DateTime postedOn { get; set; }
        public int userId { get; set; }
        public User User { get; set; }
    }
}
