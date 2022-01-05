using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Models
{
    public class AccountSubControl
    {
        [Key]
        //public int id { get; set; }
        public int accSubControlId { get; set; }
        public int accHeadId { get; set; }
        public int accControlId { get; set; }
        public string accSubControlName { get; set; }
        public DateTime postedOn { get; set; }
        public int userId { get; set; }
        public User User { get; set; }
    }
}
