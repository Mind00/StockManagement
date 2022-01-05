using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Models
{
    public class Order
    {
        [Key]
        public int orderId { get; set; }
        public DateTime date_of_order { get; set; }
        public DateTime requiredDate { get; set; }
        public DateTime shippedDate { get; set; }
        public bool status { get; set; }
        public string description { get; set; }
        public DateTime postedOn { get; set; }
        public int customerId { get; set; }
        public Customer Customer { get; set; }
    }
}
