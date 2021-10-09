using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzzaOrderingFEApplication.Models
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "UserId cannot be empty")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }
        public string jwtToken { get; set; }
    }
}
