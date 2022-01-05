using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.DTOs
{
    public class AccountSubControlDto
    {
        public int accSubControlId { get; set; }
        public int accHeadId { get; set; }
        public int accControlId { get; set; }
        public string accSubControlName { get; set; }
        public DateTime postedOn { get; set; }
        public int userId { get; set; }
    }
}
