using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Models
{
    public class AccountHead
    {
        [Key]
        public int accHeadId { get; set; }
        public string accHeadName { get; set; }
        public DateTime postedOn { get; set; }
        //Foreign key for Standard
        public int userId { get; set; }
        public User User { get; set; }
    }
}
