using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Models
{
    public class SupplierInvoiceDetail
    {
        [Key]
        public int supplierInvoiceDetailId { get; set; }
        public int supplierInvoiceId { get; set; }
        public int pId { get; set; }
        public int purchaseQuantity { get; set; }
        public int purchaseUnitPrice { get; set; }
        public DateTime postedOn { get; set; }
        public int userId { get; set; }
    }
}
