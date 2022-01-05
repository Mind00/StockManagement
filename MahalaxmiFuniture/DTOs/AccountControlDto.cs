using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.DTOs
{
    public class AccountControlDto
    {
        public int accountControlId { get; set; }
        public string accControlName { get; set; }
        public DateTime postedOn { get; set; }
        public int userId { get; set; }
        public int accHeadId { get; set; }
    }
}
