using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApi.Models
{
    public class PizzaDetailsContext:DbContext
    {
        public PizzaDetailsContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<PizzaDetails> PizzaDetails { get; set; }
    }
}
