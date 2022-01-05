using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.DTOs
{
    public class CustomerDto
    {
        public int customerId { get; set; }
        public string customerName { get; set; }
        public string address { get; set; }
        public string contactNo { get; set; }
        public string description { get; set; }
        public DateTime postedOn { get; set; }
        public int userId { get; set; }
    }
}
