using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Models
{
    public class Payroll
    {
        [Key]
        public int payrollId { get; set; }
        public float totalAmount { get; set; }
        public string payrollInvoiceNo { get; set; }
        public DateTime paymentDate { get; set; }
        public string salaryMonth { get; set; }
        public string salaryYear { get; set; }
        public float Remaining_Amount { get; set; }
        public DateTime postedOn { get; set; }
        public int eId { get; set; }
        public Employee Employee { get; set; }
        public int userId { get; set; }
    }
}
