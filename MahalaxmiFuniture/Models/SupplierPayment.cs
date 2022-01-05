using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Models
{
    public class SupplierPayment
    {
        [Key]
        public int supplierPaymentId { get; set; }
        public int sId { get; set; }
        public int supplierInvoiceId { get; set; }
        public string invoiceNo { get; set; }
        public double totalAmount { get; set; }
        public double paymentAmount { get; set; }
        public double remainingAmount { get; set; }
        public DateTime postedOn { get; set; }
        public int userId { get; set; }
    }
}
