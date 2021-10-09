using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApi.Models
{
    public class PizzaDetails
    {
        [Key]
        public string PizzaId { get; set; }
        public string PizzaName { get; set; }
        public double PizzaPrice { get; set; }
        public string PizzaDiscription { get; set; }
        public string PizzaImage { get; set; }
        public string PizzaType { get; set; }
    }
}
