using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.DTOs
{
    public class CategoryDto
    {
        public int cId { get; set; }
        public string categoryName { get; set; }
        public string description { get; set; }
        public int userId { get; set; }
        public DateTime postedOn { get; set; }
    }
}
