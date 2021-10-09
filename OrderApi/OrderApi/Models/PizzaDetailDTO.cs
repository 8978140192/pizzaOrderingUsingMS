using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models
{
    public class PizzaDetailDTO
    {
        public string PizzaId { get; set; }
        public string PizzaName { get; set; }
        public double PizzaPrice { get; set; }
        public string PizzaDiscription { get; set; }
        public string PizzaImage { get; set; }
        public string PizzaType { get; set; }
    }
}
