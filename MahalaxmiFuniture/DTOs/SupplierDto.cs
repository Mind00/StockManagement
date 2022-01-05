using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.DTOs
{
    public class SupplierDto
    {
        public int sId { get; set; }
        public string supplierName { get; set; }
        public string supplierContactNo { get; set; }
        public string supplierAddress { get; set; }
        public string email { get; set; }
        public string description { get; set; }
        public DateTime postedOn { get; set; }
        public int userId { get; set; }
    }
}
