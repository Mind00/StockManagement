using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Models
{
    public class Category
    {
        [Key]
        public int cId { get; set; }
        public string categoryName { get; set; }
        public string description { get; set; }
        public DateTime postedOn { get; set; }
        public int userId { get; set; }
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
