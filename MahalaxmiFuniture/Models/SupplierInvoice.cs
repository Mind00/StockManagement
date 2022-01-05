using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Models
{
    public class SupplierInvoice
    {
        [Key]
        public int supplierInvoiceId { get; set; }
        public int SId { get; set; }
        public string invoiceNo { get; set; }
        public double totalAmount { get; set; }
        public DateTime invoiceDate { get; set; }
        public string description { get; set; }
        public DateTime postedOn { get; set; }
        public int userId { get; set; }
    }
}
