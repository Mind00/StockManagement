using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.DTOs
{
    public class FinancialYearDto
    {
        public int financialYearId { get; set; }
        public DateTime financialYear { get; set; }
        public bool isActive { get; set; }
        public DateTime postedOn { get; set; }
        public int userId { get; set; }
    }
}
