using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Models
{
    public class Transaction
    {
        [Key]
        public int tId { get; set; }
        public int financialYear { get; set; }
        public int accountHeadId { get; set; }
        public int accountControlId { get; set; }
        public int accountSubControlId { get; set; }
        public string invoiceNo { get; set; }
        public int credit { get; set; }
        public int debit { get; set; }
        public DateTime transactionDate { get; set; }
        public string transactionTitle { get; set; }
        public DateTime postedOn { get; set; }
        public int userId { get; set; }
        public User User { get; set; }
    }
}
