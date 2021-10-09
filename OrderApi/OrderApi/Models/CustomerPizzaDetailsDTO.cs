using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models
{
    public class CustomerPizzaDetailsDTO
    {
        public int orderId { get; set; }
        public string pizzaId { get; set; }
        public bool onion { get; set; }
        public bool crispCapsicum { get; set; }
        public bool GrilledMushroom { get; set; }
        public int qty { get; set; }


    }
}
