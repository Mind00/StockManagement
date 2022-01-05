using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Models
{
    public class CustomerPayment
    {
        [Key]
        public int customerPaymentId { get; set; }
        public int customerId { get; set; }
        public int customerInvoiceId { get; set; }
        public string invoiceNo { get; set; }
        public float totalAmount { get; set; }
        public float discountPercentage { get; set; }
        public float paidAmount { get; set; }
        public float  remainingAmount { get; set; }
        public DateTime postedOn { get; set; }
        public int userId { get; set; }
    }
}
