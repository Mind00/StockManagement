using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.DTOs
{
    public class UserDto
    {
        public int userId { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public int contactNo { get; set; }
        public string address { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public bool isActive { get; set; }
        public int userTypeId { get; set; }
        public int empId { get; set; }
        public int cId { get; set; }
        public int pId { get; set; }
        public int TId { get; set; }
    }
}
