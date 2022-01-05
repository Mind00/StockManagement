using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Models
{
    public class FinancialYear
    {
        [Key]
        public int financialYearId { get; set; }
        public DateTime financialYear { get; set; }
        public bool isActive { get; set; }
        public DateTime postedOn { get; set; }
        public int userId { get; set; }
    }
}
