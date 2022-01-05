using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Models
{
    public class Employee
    {
        [Key]
        public int eId { get; set; }
        public string empFullName { get; set; }
        public string address { get; set; }
        public int contactNo { get; set; }
        public int imageId { get; set; }
        public string designation { get; set; }
        public string salary { get; set; }
        public DateTime postedOn { get; set; }
        public int userId { get; set; }
    }
}
