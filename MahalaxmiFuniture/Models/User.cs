using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public int contactNo { get; set; }
        public string address { get; set; }
        public string userName { get; set; }
        [JsonIgnore]
        public string password { get; set; }
        public bool isActive { get; set; }
        public DateTime postedOn { get; set; }
        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }
        public IEnumerable<UserType> UserTypes { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
