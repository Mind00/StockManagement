using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Models
{
    public class CustomerInvoiceDetail
    {
        [Key]
        public int customerInvoiceDetailId { get; set; }
        public int customerInvoiceId { get; set; }
        public int pId { get; set; }
        public int saleQuantity { get; set; }
        public float unitPrice { get; set; }

    }
}
