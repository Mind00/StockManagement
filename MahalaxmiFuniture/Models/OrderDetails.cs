using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Models
{
    public class OrderDetails
    {
        [Key]
        public int orderDetailId { get; set; }
        public int orderId { get; set; }
        public int pId { get; set; }
        public int quantity { get; set; }
        public int unitPrice { get; set; }
    }
}
