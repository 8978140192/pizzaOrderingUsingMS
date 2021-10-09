using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserApi.Models
{
    public class UserDetailContext:DbContext
    {
        public UserDetailContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UserDetail> Users { get; set; }
    }
}
