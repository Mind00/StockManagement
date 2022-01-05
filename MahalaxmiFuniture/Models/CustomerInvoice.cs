using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Models
{
    public class CustomerInvoice
    {
        [Key]
        public int  customerInvoiceId { get; set; }
        public int customerId { get; set; }
        public string invoiceNo { get; set; }
        public string title { get; set; }
        public float totalAmount { get; set; }
        public DateTime invoiceDate { get; set; }
        public string description { get; set; }
        public DateTime postedOn { get; set; }
        public int userId { get; set; }
    }
}
