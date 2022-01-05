using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Models
{
    public class AccountControl
    {
        [Key]
        public int accountControlId { get; set; }
        public string accControlName { get; set; }
        public DateTime postedOn { get; set; }
        // Foreign key  
        [Display(Name ="AccountHead")]
        public int accHeadId { get; set; }
        [ForeignKey("accId")]
        public virtual AccountHead AccountHeads { get; set; }

        [Display(Name = "User")]
        public virtual int userId { get; set; }

        [ForeignKey("userId")]
        public virtual User Users { get; set; }
    }
}
