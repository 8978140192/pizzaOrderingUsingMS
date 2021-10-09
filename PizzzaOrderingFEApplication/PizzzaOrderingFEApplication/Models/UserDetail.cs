using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzzaOrderingFEApplication.Models
{
    public class UserDetail
    {
        [Required(ErrorMessage = "UserId cannot be empty")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }
        [Required(ErrorMessage = "UserName cannot be empty")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "UserPhone cannot be empty")]
        public string UserPhone { get; set; }
        [Required(ErrorMessage = "UserAge cannot be empty")]
        public string UserAge { get; set; }
        [Required(ErrorMessage = "UserAddress cannot be empty")]
        public string UserAddress { get; set; }
       
    }
}
