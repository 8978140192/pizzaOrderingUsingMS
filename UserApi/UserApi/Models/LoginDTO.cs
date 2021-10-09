using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserApi.Models
{
    public class LoginDTO
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string jwtToken { get; set; }
    }
}
