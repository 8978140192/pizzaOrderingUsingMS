using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserApi.Models
{
    public class UserDetail
    {
        [Key]
        public string UserId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserAge { get; set; }
        public string UserAddress { get; set; }
    }
}
