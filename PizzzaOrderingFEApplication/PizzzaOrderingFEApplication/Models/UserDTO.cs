using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzzaOrderingFEApplication.Models
{
    public class UserDTO
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserAge { get; set; }
        public string UserAddress { get; set; }
        public string jwtToken { get; set; }
    }
}
